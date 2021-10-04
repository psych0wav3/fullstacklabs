using System.Threading.Tasks;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.Repositories;

namespace monetize.application.services
{
    public class CreateBalanceService
    {
        IBaseRepository<Balance> _repository;
        public CreateBalanceService(IBaseRepository<Balance> repository){
            _repository = repository;
        }
        
    }
}