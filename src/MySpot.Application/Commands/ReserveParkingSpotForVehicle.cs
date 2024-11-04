namespace MySpot.Api.Commands
{
    public record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId, int Capacity
        ,DateTime Date, string EmployeeName, string LicensePlate);
}
