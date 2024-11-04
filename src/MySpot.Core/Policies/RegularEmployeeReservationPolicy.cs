using MySpot.Api.Entities;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace MySpot.Core.Policies
{
    internal sealed class RegularEmployeeReservationPolicy : IReservationPolicy
    {
        private readonly IClock _clock;

        public RegularEmployeeReservationPolicy(IClock clock)
        {
            _clock = clock;
        }

        public bool CanBeApplied(JobTitle jobTitle)
            => jobTitle == JobTitle.Employee;
        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
        {
            var totalEmployeeReservation = weeklyParkingSpots
                .SelectMany(x => x.Reservations)
                .OfType<VehicleReservation>() 
                .Count(x => x.EmployeeName == employeeName);

            return totalEmployeeReservation < 2 && _clock.Current().Hour > 4;
        }
    }
}
