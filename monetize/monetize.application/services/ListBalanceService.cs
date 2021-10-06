using System.Collections.Generic;
using System.Threading.Tasks;
using monetize.domain.entities;
using monetize.domain.Repositories;
using monetize.domain.services;

namespace monetize.application.services
{
  public class ListBalanceService : IListBalanceService
  {
      private IBaseRepository<Balance> _Repository;
      public ListBalanceService(IBaseRepository<Balance> repo){
          _Repository = repo;
      }
    async public Task<List<Balance>> Execute()
    {
        return await _Repository.Read();
    }
  }
}