using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Api.Services;
using MySpot.Infrastructure.DAL;
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

            services
                .AddPostgres(configuration)
                .AddSingleton<IClock, Clock>();

            return services;
        }
    }
}
