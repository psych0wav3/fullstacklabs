
using Microsoft.EntityFrameworkCore;
using monetize.domain.entities;

namespace monetize.infra.Context
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(){
      Database.EnsureCreated();
    }
    public DbSet<Balance> Balance {get; set;}
    public DbSet<Moviments> Moviments { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder options){
      options.UseSqlite("Data Source=server.db");
    }
  }
}