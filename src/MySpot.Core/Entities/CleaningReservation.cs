using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;

namespace MySpot.Core.Entities
{
    public sealed class CleaningReservation : Reservation
    {
        public CleaningReservation(ReservationId id, Date date) : base(id, 2, date)
        {
        }
    }
}
