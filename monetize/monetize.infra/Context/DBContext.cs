
using Microsoft.EntityFrameworkCore;
using monetize.domain.entities;

namespace monetize.infra.Context
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Balance> Balance {get; set;}
    public DbSet<Moviments> Moviments { get; set; }
    public ApplicationContext( DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options){
      options.UseSqlite("Filename=./dev.sqlite");
    }
  }
}