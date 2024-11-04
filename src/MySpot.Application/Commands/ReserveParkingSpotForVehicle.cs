namespace MySpot.Api.Commands
{
    public record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId,DateTime Date, string EmployeeName, string LicensePlate);
}
