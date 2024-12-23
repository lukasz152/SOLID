﻿using MySpot.Api.Exceptions;

namespace MySpot.Core.Exceptions
{
    public sealed class WeeklyParkingSpotNotFoundException : CustomException
    {
        public Guid? Id { get; }

        public WeeklyParkingSpotNotFoundException()
            : base("Weekly parking spot with ID was not found.")
        {
        }

        public WeeklyParkingSpotNotFoundException(Guid id)
            : base($"Weekly parking spot with ID: {id} was not found.")
        {
            Id = id;
        }
    }
}
