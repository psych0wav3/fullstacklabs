using System.Collections.Generic;
using System.Threading.Tasks;
using monetize.domain.entities;
using monetize.domain.Repositories;
using monetize.domain.services;

namespace monetize.application.services
{
  public class ListMovimentsService : IListMovimentsService
  {
    private IBaseRepository<Moviments> _MovimentRepository;
    public ListMovimentsService(IBaseRepository<Moviments> MovimentRepository)
    {
        _MovimentRepository = MovimentRepository;
    }
    async public Task<List<Moviments>> Execute()
    {
        return await _MovimentRepository.Read();
    }
  }
}