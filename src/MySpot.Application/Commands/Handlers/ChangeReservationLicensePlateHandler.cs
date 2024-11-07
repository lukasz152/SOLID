﻿using MySpot.Api.Commands;
using MySpot.Api.Entities;
using MySpot.Api.Repositories;
using MySpot.Api.ValueObjects;
using MySpot.Application.Abstractions;
using MySpot.Core.Entities;
using MySpot.Application.Exceptions;

namespace MySpot.Application.Commands.Handlers
{
    public sealed class ChangeReservationLicencePlateHandler : ICommandHandler<ChangeReservationLicencePlate>
    {
        private readonly IWeeklyParkingSpotRepository _repository;

        public ChangeReservationLicencePlateHandler(IWeeklyParkingSpotRepository repository)
            => _repository = repository;

        public async Task HandleAsync(ChangeReservationLicencePlate command)
        {
            var weeklyParkingSpot = await GetWeeklyParkingSpotByReservation(command.ReservationId);
            if (weeklyParkingSpot is null)
            {
                throw new WeeklyParkingSpotNotFoundException();
            }

            var reservationId = new ReservationId(command.ReservationId);
            var reservation = weeklyParkingSpot.Reservations
                .OfType<VehicleReservation>()
                .SingleOrDefault(x => x.Id == reservationId);

            if (reservation is null)
            {
                throw new ReservationNotFoundException(command.ReservationId);
            }

            reservation.ChangeLicensePlate(command.LicencePlate);
            await _repository.UpdateAsync(weeklyParkingSpot);
        }

        private async Task<WeeklyParkingSpot> GetWeeklyParkingSpotByReservation(ReservationId id)
            => (await _repository.GetAllAsync())
                .SingleOrDefault(x => x.Reservations.Any(r => r.Id == id));
    }
}
