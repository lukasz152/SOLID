using MySpot.Api.Commands;
using MySpot.Api.DTO;

namespace MySpot.Api.Services
{
    public interface IReservationService
    {
        Task<ReservationDto> GetAsync(Guid id);
        Task<IEnumerable<ReservationDto>> GetAllWeeklyAsync();
        Task<Guid?> CreateAsync(CreateReservation command);
        Task<bool> UpdateAsync(ChangeReservationLicensePlate command);
        Task<bool> DeleteAsync(DeleteReservation command);
    }
}
