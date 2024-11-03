using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using System.Data;

namespace MySpot.Api.Repositories
{
    public interface IWeeklyParkingSpotRepository
    {
        Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id);
        Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync();
        Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) => throw new NotImplementedException();
        Task AddAsync(WeeklyParkingSpot weeklyParkingSpot);
        Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot);
        Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot);
    }
}
