using Microsoft.Extensions.DependencyInjection;
using monetize.infra.Context;

namespace monetize.crosscutting
{
    public static class DependencyInjectionContext
    {
        public static IServiceCollection Execute(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationContext>();
            return service;
        }
  }
}