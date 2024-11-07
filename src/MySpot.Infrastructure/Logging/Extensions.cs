using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Application.Abstractions;
using MySpot.Infrastructure.Logging.Decorators;
using Serilog;

namespace MySpot.Infrastructure.Logging
{
    public static class Extensions
    {
        internal static IServiceCollection AddCustomLogging(this IServiceCollection services) 
        {
            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));
            return services;
        }
    }
}
