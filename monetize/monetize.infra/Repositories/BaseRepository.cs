using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using monetize.domain.entities;
using monetize.domain.Repositories;
using monetize.infra.Context;

namespace monetize.infra.Repositories
{
  public class BaseRepository<T> : IBaseRepository<T> where T : Entity
  {
    private readonly ApplicationContext _context;

    public BaseRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<T> Create(T entity)
    {
        await CreateSet().AddAsync(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        CreateSet().Remove(entity);
    }

    async public Task<T> GetById(T entity)
    {
        return await CreateSet().FindAsync(entity.Id);
    }

    public async Task<List<T>> Read()
    {
       return await CreateSet().AsNoTracking().ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public T Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return entity;
    }

    private DbSet<T> CreateSet()
    {
        return _context.Set<T>();
    }
    
  }
}