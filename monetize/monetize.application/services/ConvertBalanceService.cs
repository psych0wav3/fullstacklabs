using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.enums;
using monetize.domain.Repositories;
using monetize.domain.services;

namespace monetize.application.services
{
  public class ConvertBalanceService : IConvertBalanceService
  {
    private IBaseRepository<Balance> _BalanceRepository;
    private IBaseRepository<Moviments> _MovimentsRepository;
    private IConfiguration _config;
    private double USD;
    private double EUR;
    private double IOF;
    private double Spread;

    private List<Balance> ActualBalances;

    private Balance BRLBalance;


    public ConvertBalanceService(
      IBaseRepository<Balance> BalanceRepository,
      IBaseRepository<Moviments> MovimentsRepository,
      IConfiguration iconfig
    ){
        _BalanceRepository = BalanceRepository;
        _MovimentsRepository = MovimentsRepository;
        _config = iconfig;
        USD = double.Parse(_config.GetSection("USD").Value);
        EUR = double.Parse(_config.GetSection("EUR").Value);
        IOF = double.Parse(_config.GetSection("IOF").Value) / 100;
        Spread = double.Parse(_config.GetSection("spread").Value) / 100;
    }
    async public void Execute(ConvertBalanceDTO balanceDTO)
    {
        switch(balanceDTO.Currency)
      {
        case Currency.USD:
          double USDValue = ConvertCoin(balanceDTO.Value, USD);
          ActualBalances = await _BalanceRepository.Read();
          Balance balance = ActualBalances.Find(item => item.Currency == Currency.USD);
          BRLBalance = ActualBalances.Find(item => item.Currency == Currency.BRL);
          BRLBalance.UpdateValue(BRLBalance.Value - balanceDTO.Value);
          _BalanceRepository.Update(BRLBalance);
          balance.UpdateValue(balance.Value + USDValue);  
          _BalanceRepository.Update(balance);
          await _BalanceRepository.SaveChangesAsync();
          Moviments  moviment = new Moviments(USDValue, MovimentEnum.Convert, Currency.BRL, Currency.USD);
          await _MovimentsRepository.Create(moviment);
          await _MovimentsRepository.SaveChangesAsync();
          break;
        case Currency.EUR:
          double EURValue = ConvertCoin(balanceDTO.Value, EUR);
          ActualBalances = await _BalanceRepository.Read();
          Balance EURbalance = ActualBalances.Find(item => item.Currency == Currency.EUR);
          BRLBalance = ActualBalances.Find(item => item.Currency == Currency.BRL);
          BRLBalance.UpdateValue(BRLBalance.Value - balanceDTO.Value);
          _BalanceRepository.Update(BRLBalance);
          EURbalance.UpdateValue(EURbalance.Value + EURValue);  
          _BalanceRepository.Update(EURbalance);
          await _BalanceRepository.SaveChangesAsync();
          Moviments  _moviment = new Moviments(EURValue, MovimentEnum.Convert, Currency.BRL, Currency.EUR);
          await _MovimentsRepository.Create(_moviment);
          await _MovimentsRepository.SaveChangesAsync();
          break;
      }
    }

    private double ConvertCoin(double balance, double CoinValue)
    {
      double ConvertedValue;
      double IOFPercentage;
      double SpreadPercentage;
      
      ConvertedValue = (balance / CoinValue);
      IOFPercentage = IOF * ConvertedValue;
      SpreadPercentage = Spread * ConvertedValue;
      ConvertedValue = (ConvertedValue - IOFPercentage) - SpreadPercentage; 
      return Math.Round(ConvertedValue, 2);
    }
  }
}