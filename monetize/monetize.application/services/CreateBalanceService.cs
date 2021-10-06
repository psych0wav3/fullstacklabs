using System;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.Repositories;
using monetize.domain.services;

namespace monetize.application.services
{
    public class CreateBalanceService : ICreateBalanceService
    {
        private IBaseRepository<Balance> _Repository;
        public CreateBalanceService(IBaseRepository<Balance> repository)
        {
            _Repository = repository;
        }

        async public void Execute(CreateBalanceDTO CreateBalance)
        {
          try
          {
            Balance balance = new Balance(CreateBalance.Value, CreateBalance.Currency);
            await _Repository.Create(balance);
            await _Repository.SaveChangesAsync();
          }
          catch(Exception err)
          {
            throw new Exception(err.Message);
          }
        }
  }
}