using MySpot.Application.Abstractions;

namespace MySpot.Api.Commands
{
    public sealed record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId, Guid UserId,
    string LicencePlate, int Capacity, DateTime Date) : ICommand;
}
