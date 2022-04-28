using CrossCutting.Infra.Repository;
using Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace CrossCutting.Injector
{
    public static class CrossCuttingInfraExtensions
    {
        public static void RegisterServicesCrossCuttingInfra(this IServiceCollection services)
        {
            services.AddScoped<ITruckRepository,TruckRepository>();
        }
    }
}