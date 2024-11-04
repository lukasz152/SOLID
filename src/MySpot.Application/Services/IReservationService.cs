using MySpot.Api.Commands;
using MySpot.Api.DTO;
using MySpot.Application.Commands;

namespace MySpot.Api.Services
{
    public interface IReservationService
    {
        Task<ReservationDto> GetAsync(Guid id);
        Task<IEnumerable<ReservationDto>> GetAllWeeklyAsync();
        Task<Guid?> ReserveForVehicleAsync(ReserveParkingSpotForVehicle command);
        Task ReserveForCleaningAsync(ReserveParkingSpotForCleaning command);
        Task<bool> ChangeReservationLicensePlateAsync(ChangeReservationLicensePlate command);
        Task<bool> DeleteAsync(DeleteReservation command);
    }
}
