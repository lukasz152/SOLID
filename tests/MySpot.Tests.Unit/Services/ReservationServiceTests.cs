using MySpot.Api.Commands;
using MySpot.Api.Repositories;
using MySpot.Api.Services;
using MySpot.Core.DomainServices;
using MySpot.Infrastructure.DAL.Repositories;
using MySpot.Tests.Unit.Shared;
using Shouldly;


namespace MySpot.Tests.Unit.Services
{
    public class ReservationServiceTests
    {
        //[Fact]
        //public async Task given_reservation_for_not_taken_date_create_reservation_should_succeed()
        //{
        //    //Arrange
        //    var parkingSpot = (await _weeklyParkingSpotRepository.GetAllAsync()).First();
        //    var command = new CreateReservation(parkingSpot.Id,
        //        Guid.NewGuid(), DateTime.UtcNow.AddMinutes(5), "John DOe", "XYZ123");
            
        //    //Act
        //    var reservationId = await _reservationService.CreateAsync(command);

        //    //Assert
        //    reservationId.ShouldNotBeNull();
        //    reservationId.Value.ShouldBe(command.ReservationId);
        //}

        //#region Arrange

        //private readonly IClock _clock;
        //private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
        //private readonly IReservationService _reservationService;
        //private readonly IParkingReservationService _parkingReservationService;

        //public ReservationServiceTests()
        //{
        //    _clock = new TestClock();
        //    _weeklyParkingSpotRepository = new InMemoryWeeklyParkingSpotRepository(_clock);
        //}

        //#endregion
    }
}
