using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;

namespace MySpot.Core.Entities
{
    public sealed class CleaningReservation : Reservation
    {
        private CleaningReservation()
        {
            
        }

        public CleaningReservation(ReservationId id, ParkingSpotId parkingSpotId, Date date) : base(id, parkingSpotId, date)
        {
        }
    }
}
