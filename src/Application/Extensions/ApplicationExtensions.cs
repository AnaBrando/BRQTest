using Application.UseCase.CreateTrunk;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage]
public static class ApplicationExtensions
    {
        public static void RegisterServicesApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateTruckCommandHandler));
        }
    }