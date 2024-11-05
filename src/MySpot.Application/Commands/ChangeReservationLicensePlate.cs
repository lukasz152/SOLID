using MySpot.Application.Abstractions;

namespace MySpot.Api.Commands
{
    public sealed record ChangeReservationLicencePlate(Guid ReservationId, string LicencePlate) : ICommand;
}
