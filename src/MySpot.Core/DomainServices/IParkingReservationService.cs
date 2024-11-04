using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.DomainServices
{
    public interface IParkingReservationService
    {
        void ReserveSpotForVehicle(IEnumerable<WeeklyParkingSpot> allParkingSpots, JobTitle jobTitle,
            WeeklyParkingSpot parkingSpotToReserve, VehicleReservation vehicleReservation);
        void ReserveParkingForCleaning(IEnumerable<WeeklyParkingSpot> allParkingSpots, Date date);
    }
}
