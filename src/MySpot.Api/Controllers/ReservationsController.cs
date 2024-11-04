using Microsoft.AspNetCore.Mvc;
using MySpot.Api.Commands;
using MySpot.Api.DTO;
using MySpot.Api.Services;
using MySpot.Application.Commands;

namespace MySpot.Api.Controllers
{
    [ApiController] // automatyczne bindowanie frombody 
    [Route("reservations")]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> Get()
            => Ok(await _reservationService.GetAllWeeklyAsync());


        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReservationDto>> Get(Guid id)
        {
            var reservation = await _reservationService.GetAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        [HttpPost("vehicle")]
        public async Task<ActionResult> Post(ReserveParkingSpotForVehicle command)
        {
            var id = await _reservationService.ReserveForVehicleAsync(command with { ReservationId = Guid.NewGuid() });
            if (id == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id }, null);
        }


        [HttpPost("cleaning")]
        public async Task<ActionResult> Post(ReserveParkingSpotForCleaning command)
        {
            await _reservationService.ReserveForCleaningAsync(command);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, ChangeReservationLicensePlate command)
        {
            if (await _reservationService.ChangeReservationLicensePlateAsync(command with { ReservationId = id }))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (await _reservationService.DeleteAsync(new DeleteReservation(id)))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}