using System.Collections.Generic;
using System.Threading.Tasks;
using monetize.domain.entities;

namespace monetize.domain.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> Create( T entity);
        T Update( T entity);
        void Delete( T entity);
        Task<List<T>> Read();
        Task SaveChangesAsync();
        Task<T> GetById(T entity);
    }
}