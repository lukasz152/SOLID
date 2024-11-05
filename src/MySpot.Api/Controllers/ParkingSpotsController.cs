using Microsoft.AspNetCore.Mvc;
using MySpot.Api.Commands;
using MySpot.Application.Abstractions;
using MySpot.Application.Commands;
using MySpot.Application.DTO;
using MySpot.Application.Queries;

namespace MySpot.Api.Controllers
{
    [ApiController] // automatyczne bindowanie frombody 
    [Route("parking-spots")]
    public class ParkingSpotsController : ControllerBase
    {
        private readonly ICommandHandler<ReserveParkingSpotForVehicle> _reserveParkingSpotForVehicleHandler;
        private readonly ICommandHandler<ReserveParkingSpotForCleaning> _reserveParkingSpotForCleaningHandler;
        private readonly ICommandHandler<ChangeReservationLicencePlate> _changeReservationLicencePlateHandler;
        private readonly ICommandHandler<DeleteReservation> _deleteReservationHandler;
        private readonly IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDto>> _getWeeklyParkingSpotsHandler;
        public ParkingSpotsController(ICommandHandler<ReserveParkingSpotForVehicle> ReserveParkignSpotForVehicleHandler,
            ICommandHandler<ReserveParkingSpotForCleaning> ReserveParkingSpotForCleaningHandler,
            ICommandHandler<ChangeReservationLicencePlate> ChangeReservationLicencePlateHandler,
            ICommandHandler<DeleteReservation> DeleteReservationHandler,
            IQueryHandler<GetWeeklyParkingSpots, IEnumerable<WeeklyParkingSpotDto>> GetWeeklyParkingSpotsHandler)
        {
            _reserveParkingSpotForCleaningHandler = ReserveParkingSpotForCleaningHandler;
            _reserveParkingSpotForVehicleHandler = ReserveParkignSpotForVehicleHandler;
            _changeReservationLicencePlateHandler = ChangeReservationLicencePlateHandler;
            _deleteReservationHandler = DeleteReservationHandler;
            _getWeeklyParkingSpotsHandler = GetWeeklyParkingSpotsHandler;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeeklyParkingSpotDto>>> Get([FromQuery] GetWeeklyParkingSpots query)
            => Ok(await _getWeeklyParkingSpotsHandler.HandleAsync(query));

        [HttpPost("{parkingSpotId:guid}/reservations/vehicle")]
        public async Task<ActionResult> Post(Guid parkingSpotId, ReserveParkingSpotForVehicle command)
        {
            await _reserveParkingSpotForVehicleHandler.HandleAsync(command with 
            { 
                ReservationId = Guid.NewGuid(),
                ParkingSpotId = parkingSpotId
            });
            return NoContent();
        }


        [HttpPost("reservations/cleaning")]
        public async Task<ActionResult> Post(ReserveParkingSpotForCleaning command)
        {
            await _reserveParkingSpotForCleaningHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpPut("reservations/{reservationId:guid}")]
        public async Task<ActionResult> Put(Guid reservationId, ChangeReservationLicencePlate command)
        {
            await _changeReservationLicencePlateHandler.HandleAsync(command with { ReservationId = reservationId });

            return NotFound();
        }

        [HttpDelete("reservations/{reservationId:guid}")]
        public async Task<ActionResult> Delete(Guid reservationId)
        {
            await _deleteReservationHandler.HandleAsync(new DeleteReservation(reservationId));

            return NotFound();
        }
    }
}