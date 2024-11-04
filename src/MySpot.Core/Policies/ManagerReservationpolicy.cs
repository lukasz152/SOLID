﻿using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Policies
{
    internal class ManagerReservationpolicy : IReservationPolicy
    {
        public bool CanBeApplied(JobTitle jobTitle)
            =>jobTitle == JobTitle.Manager;

        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
        {
            var totalEmployeeReservation = weeklyParkingSpots
               .SelectMany(x => x.Reservations)
               .OfType<VehicleReservation>()
               .Count(x => x.EmployeeName == employeeName);

            return totalEmployeeReservation <=4;
        }
    }
}
