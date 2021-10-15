using System.Collections.Generic;
using System.Net;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.enums;
using monetize.domain.Repositories;
using monetize.domain.services;

namespace monetize.application.services
{
  public class UpdateBalanceService : IUpdateBalanceService
  {
      private IBaseRepository<Balance> _BalanceRepo;
      private IBaseRepository<Moviments> _MovimentRepo;
      public UpdateBalanceService(IBaseRepository<Balance> BalanceRepo, IBaseRepository<Moviments> MovimentRepo){
          _BalanceRepo = BalanceRepo;
          _MovimentRepo = MovimentRepo;
      }
    async public void Execute(UpdateBalanceDTO updateBalace)
    {
          List<Balance> ActualBalances = await _BalanceRepo.Read();
          Balance BRLBalance = ActualBalances.Find(item => item.Currency == Currency.BRL);
          BRLBalance.UpdateValue(BRLBalance.Value + updateBalace.Value);  
          _BalanceRepo.Update(BRLBalance);
          await _BalanceRepo.SaveChangesAsync();
          Moviments  moviment = new Moviments(updateBalace.Value, MovimentEnum.Add, BRLBalance.Currency, BRLBalance.Currency);
          await _MovimentRepo.Create(moviment);
          await _MovimentRepo.SaveChangesAsync();
    }
  }
}