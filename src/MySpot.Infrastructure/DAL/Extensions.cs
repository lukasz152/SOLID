﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpot.Api.Repositories;
using MySpot.Application.Abstractions;
using MySpot.Core.Repositories;
using MySpot.Infrastructure.DAL.Decorators;
using MySpot.Infrastructure.DAL.Repositories;
using MySpot.Infrastructure.Logging.Decorators;

namespace MySpot.Infrastructure.DAL
{
    public static class Extensions
    {
        private const string OptionsSectionName = "postgres";

        public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
            var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);
            services.AddDbContext<MySpotDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
            services.AddScoped<IWeeklyParkingSpotRepository, PostgresWeeklyParkingSpotRepository>();
            services.AddScoped<IUserRepository, PostgresUserRepository>();
            services.AddHostedService<DatabaseInitializer>();
            services.AddScoped<IUnitOfWork, PostgresUnitOfWork>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            return services;
        }
    }
}
