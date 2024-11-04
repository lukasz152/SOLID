using MySpot.Api.Entities;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using MySpot.Core.Policies;
using MySpot.Core.ValueObjects;
using System.Runtime.InteropServices.JavaScript;

namespace MySpot.Core.DomainServices
{
    internal sealed class ParkingReservationService : IParkingReservationService
    {
        private readonly IEnumerable<IReservationPolicy> _polices;
        private readonly IClock _clock;

        public ParkingReservationService(IEnumerable<IReservationPolicy> polices ,IClock clock)
        {
            _clock = clock;
            _polices = polices;
        }

        public void ReserveParkingForCleaning(IEnumerable<WeeklyParkingSpot> allParkingSpots, Date date)
        {
            foreach (var parkingSpot in allParkingSpots)
            {
                var reservationForSameDate = parkingSpot.Reservations.Where(x => x.Date == date);
                parkingSpot.RemoveReservations(reservationForSameDate);

                var cleaningReservation = new CleaningReservation(ReservationId.Create(), parkingSpot.Id, date);
                parkingSpot.AddReservation(cleaningReservation, new Date(_clock.Current()));
            }
        }

        public void ReserveSpotForVehicle(IEnumerable<WeeklyParkingSpot> allParkingSpots, JobTitle jobTitle, 
            WeeklyParkingSpot parkingSpotToReserve, VehicleReservation reservation)
        {
            var parkingSpotId = parkingSpotToReserve.Id;
            var policy = _polices.SingleOrDefault(x => x.CanBeApplied(jobTitle));

            if (policy is null)
            {
                throw new NoReservationPolicyFoundException(jobTitle);
            }

            if (!policy.CanReserve(allParkingSpots, reservation.EmployeeName))
            {
                throw new CannotReserveParkingSpotException(parkingSpotId);
            }

            parkingSpotToReserve.AddReservation(reservation, new Api.ValueObjects.Date(_clock.Current()));
        }
    }
}
