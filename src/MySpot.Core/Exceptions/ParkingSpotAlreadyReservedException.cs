namespace MySpot.Api.Exceptions
{
    public sealed class ParkingSpotAlreadyReservedException : CustomException
    {
        public string ParkingSpotName { get; }
        public DateTime Date { get; }

        public ParkingSpotAlreadyReservedException(string parkingSpotName, DateTime date) : base($"Parking spot :{parkingSpotName} is already reserved at :{date:d}")
        {
            ParkingSpotName = parkingSpotName;
            Date = date;
        }
    }
}
