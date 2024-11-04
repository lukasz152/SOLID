using MySpot.Api.Entities;
using MySpot.Api.Exceptions;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;
using MySpot.Core.Exceptions;
using Shouldly;
using Xunit;

namespace MySpot.Tests.Unit.Entities
{
    public class WeeklyParkingSpotTests
    {
        [Theory]
        [InlineData("2024-10-20")]
        [InlineData("2024-10-29")]
        public void given_invalid_date_add_reservation_should_fail(string dateString)
        {
            //Arrange
            var invalidDate = DateTime.Parse(dateString);
            var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John doe",
                "XYZ123", 1, new Date(invalidDate));

            //Act
            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, new Date(_now)));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidReservationDateException>();
            //Assert.NotNull(exception);
            //Assert.IsType<InvalidReservationDateException>(exception);
        }

        [Fact]
        public void given_reservation_for_already_reserved_parking_spot_add_reservation_should_fail()
        {
            //Arrange
            var reservationDate = _now.AddDays(1);
            var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe",
                "XYZ123", 2, reservationDate);
            
            var nextReservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe",
                "XYZ123", 1, reservationDate);

            _weeklyParkingSpot.AddReservation(reservation, _now);

            //Act
            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(nextReservation, reservationDate));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ParkingSpotCapacityExceededException>();
        }

        [Fact]
        public void given_reservation_for_not_reserved_spot_date_add_reservation_should_succeed()
        {
            var reservationDate = _now.AddDays(1);
            var reservation = new VehicleReservation(Guid.NewGuid(), _weeklyParkingSpot.Id, "John Doe",
                "XYZ123", 1, reservationDate);

            //act
            _weeklyParkingSpot.AddReservation(reservation, _now);

            //assert
            _weeklyParkingSpot.Reservations.ShouldHaveSingleItem();
        }

        #region Arrange

        private readonly Date _now;

        private readonly WeeklyParkingSpot _weeklyParkingSpot;
        public WeeklyParkingSpotTests()
        {
            _now = new Date(new DateTime(2024, 10, 21));
            _weeklyParkingSpot = WeeklyParkingSpot.Create(Guid.NewGuid(), new Week(_now), "P1");
        }
        #endregion
    }
}
