using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using monetize.application.services;
using monetize.domain.Repositories;
using monetize.infra.Context;
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