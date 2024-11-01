using MySpot.Api.Commands;
using MySpot.Api.DTO;

namespace MySpot.Api.Services
{
    public interface IReservationService
    {
        ReservationDto Get(Guid id);
        IEnumerable<ReservationDto> GetAllWeekly();
        public Guid? Create(CreateReservation command);
        public bool Update(ChangeReservationLicensePlate command);
        public bool Delete(DeleteReservation command);
    }
}
