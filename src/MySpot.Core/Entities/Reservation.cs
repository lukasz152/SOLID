using MySpot.Api.ValueObjects;
using MySpot.Core.ValueObjects;

namespace MySpot.Api.Entities
{
    public abstract class Reservation
    {
        public ReservationId Id { get; }
        public ParkingSpotId ParkingSpotId { get; private set; }
        public Date Date { get; private set; }
        public Capacity Capacity { get; private set; }

        protected Reservation() { }

        public Reservation(ReservationId id, ParkingSpotId parkingSpotId, Capacity capacity, Date date)
        {
            Id = id;
            ParkingSpotId = parkingSpotId;
            Date = date;
            Capacity = capacity;
        }
    }
}
