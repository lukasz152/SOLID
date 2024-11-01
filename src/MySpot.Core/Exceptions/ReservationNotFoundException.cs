namespace MySpot.Api.Exceptions
{
    public class ReservationNotFoundException :CustomException
    {
        public Guid Id { get; }
        public ReservationNotFoundException(Guid id) : base($"Reservation with Id:{id} was not found")
        {
            Id = id;
        }
    }
}
