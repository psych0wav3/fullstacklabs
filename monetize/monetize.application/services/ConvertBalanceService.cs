using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.Repositories;

namespace monetize.application.services
{
    public class ConvertBalanceService
    {
        IBaseRepository<Balance> _Repository;
        public ConvertBalanceService(IBaseRepository<Balance> repository){
            _Repository = repository;
        }
    }
}