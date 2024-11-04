using MySpot.Api.Exceptions;
using MySpot.Api.ValueObjects;

namespace MySpot.Core.Exceptions
{
    public sealed class ParkingSpotCapacityExceededException : CustomException
    {
        public ParkingSpotId ParkingSpotId { get; }

        public ParkingSpotCapacityExceededException(ParkingSpotId parkingSpotId) 
            : base($"Parking spot with ID: {parkingSpotId} exceeds its reservation capacity.")
        {
            parkingSpotId = parkingSpotId;
        }
    }
}
