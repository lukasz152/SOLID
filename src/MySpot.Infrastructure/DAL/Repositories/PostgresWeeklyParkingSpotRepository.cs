using Microsoft.EntityFrameworkCore;
using MySpot.Api.Entities;
using MySpot.Api.Repositories;
using MySpot.Api.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories
{
    internal sealed class PostgresWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
    {
        private readonly MySpotDbContext _dbContext;

        public PostgresWeeklyParkingSpotRepository(MySpotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<WeeklyParkingSpot> GetAsync(ParkingSpotId id) 
            => _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .SingleOrDefaultAsync(x => x.Id == id);
        
        public async Task<IEnumerable<WeeklyParkingSpot>> GetByWeekAsync(Week week) 
            => await _dbContext.WeeklyParkingSpots
            .Include(x => x.Reservations)
            .Where(x => x.Week == week)
            .ToListAsync();

        public async Task<IEnumerable<WeeklyParkingSpot>> GetAllAsync()
        {
            var result = await _dbContext.WeeklyParkingSpots   // why await ?
            .Include(x => x.Reservations)
            .ToListAsync();

            return result.AsEnumerable();
        }

        public async Task AddAsync(WeeklyParkingSpot weeklyParkingSpot)
        {
            await _dbContext.AddAsync(weeklyParkingSpot);
        }

        public Task UpdateAsync(WeeklyParkingSpot weeklyParkingSpot)
        {
            _dbContext.Update(weeklyParkingSpot);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(WeeklyParkingSpot weeklyParkingSpot)
        {
            _dbContext.Remove(weeklyParkingSpot);
            await _dbContext.SaveChangesAsync();
        }

    }
}
