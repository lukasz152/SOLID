using Microsoft.Extensions.DependencyInjection;
using MySpot.Api.Commands;
using MySpot.Application.Abstractions;
using MySpot.Application.Commands.Handlers;

namespace MySpot.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<ICommandHandler<ReserveParkingSpotForVehicle>, ReserveParkingSpotForVehicleHandler>();
            //lub
            var applicationAssembly = typeof(ICommandHandler<>).Assembly;

            //services.AddScoped<ICommandHandler<ReserveParkingSpotForVehicle>, ReserveParkingSpotForVehicleHandler>();

            services.Scan(s => s.FromAssemblies(applicationAssembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
            return services;
        }
    }
}
