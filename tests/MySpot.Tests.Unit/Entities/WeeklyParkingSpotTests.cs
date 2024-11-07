﻿using MySpot.Api.Entities;
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
        [InlineData("2024-02-02")]
        [InlineData("2024-02-02")]
        [InlineData("2024-02-24")]
        public void given_invalid_date_add_reservation_should_fail(string dateString)
        {
            var invalidDate = DateTime.Parse(dateString);

            //ARRANGE
            var reservation = new VehicleReservation(Guid.NewGuid(), Guid.NewGuid(), "Joe Doe", "XYZ123", 1, new Date(invalidDate));

            //ACT
            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, _now));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<InvalidReservationDateException>();
        }

        [Fact]
        public void given_reservation_for_already_existing_date_add_reservation_should_fail()
        {
            //ARRANGE
            var reservationDate = _now.AddDays(1);
            var reservation = new VehicleReservation(Guid.NewGuid(), Guid.NewGuid(), "Joe Doe", "XYZ123", 1, reservationDate);
            _weeklyParkingSpot.AddReservation(reservation, reservationDate);

            //ACT
            var exception = Record.Exception(() => _weeklyParkingSpot.AddReservation(reservation, reservationDate));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ParkingSpotAlreadyReservedException>();
        }

        [Fact]
        public void given_reservation_for_not_taken_date_add_reservation_should_succeed()
        {
            //ARRANGE
            var reservationDate = _now.AddDays(1);
            var reservation = new VehicleReservation(Guid.NewGuid(), Guid.NewGuid(), "Joe Doe", "XYZ123", 1, reservationDate);

            //ACT
            _weeklyParkingSpot.AddReservation(reservation, reservationDate);

            //ASSERT
            _weeklyParkingSpot.Reservations.ShouldHaveSingleItem();
            _weeklyParkingSpot.Reservations.ShouldContain(reservation);
        }

        #region ARRANGE

        private readonly WeeklyParkingSpot _weeklyParkingSpot;
        private readonly Date _now;

        public WeeklyParkingSpotTests()
        {
            _now = new Date(DateTime.Parse("2024-02-25"));
            _weeklyParkingSpot = WeeklyParkingSpot.Create(Guid.NewGuid(), new Week(_now), "P1");
        }

        #endregion
    }
}
