using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Api.Services;
using MySpot.Application.Abstractions;
using MySpot.Infrastructure.DAL;
using MySpot.Infrastructure.DAL.Exceptions;
using MySpot.Infrastructure.Logging;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("MySpot.Tests.Unit")]
namespace MySpot.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var section = configuration.GetSection("app");
            services.Configure<AppOptions>(section);

            services.AddSingleton<ExceptionMiddleware>();

            services
                .AddPostgres(configuration)
                .AddSingleton<IClock, Clock>();


            var InfrastructureAssembly = typeof(AppOptions).Assembly;


            services.Scan(s => s.FromAssemblies(InfrastructureAssembly)
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddCustomLogging();


            return services;
        }

        public static WebApplication UseInfrastructure(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.MapControllers();

            return app;
        }
    }
}
