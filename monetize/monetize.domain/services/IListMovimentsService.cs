using System.Collections.Generic;
using System.Threading.Tasks;
using monetize.domain.entities;

namespace monetize.domain.services
{
    public interface IListMovimentsService
    {
        Task<List<Moviments>> Execute();
    }
}