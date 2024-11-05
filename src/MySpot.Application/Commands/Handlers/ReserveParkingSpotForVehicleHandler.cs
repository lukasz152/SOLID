using MySpot.Api.Commands;
using MySpot.Api.Repositories;
using MySpot.Api.Services;
using MySpot.Api.ValueObjects;
using MySpot.Application.Abstractions;
using MySpot.Application.Exceptions;
using MySpot.Core.DomainServices;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Application.Commands.Handlers
{
    public sealed class ReserveParkingSpotForVehicleHandler : ICommandHandler<ReserveParkingSpotForVehicle>
    {
        private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
        private static IClock _clock;
        private readonly IParkingReservationService _parkingReservationService;

        public ReserveParkingSpotForVehicleHandler(IClock clock, IWeeklyParkingSpotRepository weeklyParkingSpotRepository, 
            IParkingReservationService parkingReservation)
        {
            _weeklyParkingSpotRepository = weeklyParkingSpotRepository;
            _parkingReservationService = parkingReservation;
            _clock = clock;
        }

        public async Task HandleAsync(ReserveParkingSpotForVehicle command)
        {
            var parkingSpotId = new ParkingSpotId(command.ParkingSpotId);
            var week = new Week(_clock.Current());

            var weeklyParkingSpots = (await _weeklyParkingSpotRepository.GetByWeekAsync(week)).ToList();
            var parkingSpotToReserve = weeklyParkingSpots.SingleOrDefault(x => x.Id == parkingSpotId);

            if (parkingSpotToReserve is null)
            {
                throw new WeeklyParkingSpotNotFoundException(parkingSpotId);
            }

            var reservation = new VehicleReservation(command.ReservationId, command.ParkingSpotId, command.EmployeeName,
                command.LicensePlate, command.Capacity, new Date(command.Date));

            _parkingReservationService.ReserveSpotForVehicle(weeklyParkingSpots, JobTitle.Employee, parkingSpotToReserve, reservation);

            await _weeklyParkingSpotRepository.UpdateAsync(parkingSpotToReserve);
        }
    }
}
