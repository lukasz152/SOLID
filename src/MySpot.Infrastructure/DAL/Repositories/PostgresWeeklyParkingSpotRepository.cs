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

        public WeeklyParkingSpot Get(ParkingSpotId id) => 
            _dbContext.WeeklyParkingSpot
            .Include(x => x.Reservations)
            .SingleOrDefault(x => x.Id == id);

        public IEnumerable<WeeklyParkingSpot> GetAll()
            => _dbContext.WeeklyParkingSpot
            .Include(x => x.Reservations)
            .ToList();

        public void Add(WeeklyParkingSpot weeklyParkingSpot)
        {
            _dbContext.Add(weeklyParkingSpot);
            _dbContext.SaveChanges();
        }

        public void Update(WeeklyParkingSpot weeklyParkingSpot)
        {
            _dbContext.Update(weeklyParkingSpot);
            _dbContext.SaveChanges();
        }

        public void Delete(WeeklyParkingSpot weeklyParkingSpot)
        {
            _dbContext.Remove(weeklyParkingSpot);
            _dbContext.SaveChanges();
        }

    }
}
