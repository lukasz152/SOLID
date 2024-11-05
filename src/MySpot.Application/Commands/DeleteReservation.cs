using MySpot.Application.Abstractions;

namespace MySpot.Api.Commands
{
    public record DeleteReservation(Guid ReservationId) : ICommand;
}
