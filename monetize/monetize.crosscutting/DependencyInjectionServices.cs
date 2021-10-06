using Microsoft.Extensions.DependencyInjection;
using monetize.application.services;
using monetize.domain.services;

namespace monetize.crosscutting
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection Execute(this IServiceCollection service)
        {
            service.AddTransient<ICreateBalanceService ,CreateBalanceService>();
            service.AddTransient<IUpdateBalanceService ,UpdateBalanceService>();
            service.AddTransient<IHttpRates, HttpRates>();
            service.AddTransient<IListBalanceService, ListBalanceService>();
            return service;
        }
    }
}