using Microsoft.Extensions.DependencyInjection;
using monetize.domain.Repositories;
using monetize.infra.Repositories;

namespace monetize.crosscutting
{
    public static class DependencyInjectionReposytory
    {
        public static IServiceCollection Execute(this IServiceCollection service)
        {
            service.AddTransient(typeof(IBaseRepository < > ), typeof(BaseRepository < > ));
            return service;
        }
    }
}