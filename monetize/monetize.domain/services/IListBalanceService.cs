using System.Collections.Generic;
using System.Threading.Tasks;
using monetize.domain.entities;

namespace monetize.domain.services
{
    public interface IListBalanceService
    {
         Task<List<Balance>> Execute(); 
    }
}