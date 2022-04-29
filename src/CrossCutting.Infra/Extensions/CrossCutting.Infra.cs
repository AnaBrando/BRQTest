using CrossCutting.Infra;
using CrossCutting.Infra.Repository;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CrossCutting.Injector
{
    [ExcludeFromCodeCoverage]
    public static class CrossCuttingInfraExtensions
    {
        public static void RegisterServicesCrossCuttingInfra(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITruckRepository, TruckRepository>();
            var connection = config.GetConnectionString("ConnectionStrings:SqlConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(""));
        }
    }
}