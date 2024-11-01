﻿using Microsoft.Extensions.DependencyInjection;
using MySpot.Api.Services;

namespace MySpot.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IReservationService, ReservationService>();

            return services;
        }
    }
}
