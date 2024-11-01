using MySpot.Api.Entities;
using MySpot.Api.Repositories;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;

namespace MySpot.Infrastructure.DAL.Repositories
{
    internal class InMemoryWeeklyParkingSpotRepository : IWeeklyParkingSpotRepository
    {
        private readonly List<WeeklyParkingSpot> _weeklyParkingSpots;

        public InMemoryWeeklyParkingSpotRepository(IClock clock)
        {
            _weeklyParkingSpots = new List<WeeklyParkingSpot>()
            {
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000001"), new Week(clock.Current()), "P1"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000002"), new Week(clock.Current()), "P2"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000003"), new Week(clock.Current()), "P3"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000004"), new Week(clock.Current()), "P4"),
            new WeeklyParkingSpot(Guid.Parse("00000000-0000-0000-0000-000000000005"), new Week(clock.Current()), "P5"),
            };
        }


        public WeeklyParkingSpot Get(ParkingSpotId id) => _weeklyParkingSpots.FirstOrDefault(sp => sp.Id == id);

        public IEnumerable<WeeklyParkingSpot> GetAll() => _weeklyParkingSpots;

        public void Add(WeeklyParkingSpot weeklyParkingSpot)
        {
            _weeklyParkingSpots.Add(weeklyParkingSpot);
        }
        public void Update(WeeklyParkingSpot weeklyParkingSpot)
        {
        }
        public void Delete(WeeklyParkingSpot weeklyParkingSpot)
        {
            _weeklyParkingSpots.Remove(weeklyParkingSpot);
        }

    }
}
