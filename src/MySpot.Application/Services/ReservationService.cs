﻿using MySpot.Api.Commands;
using MySpot.Api.DTO;
using MySpot.Api.Entities;
using MySpot.Api.Repositories;
using MySpot.Api.ValueObjects;
using System.Linq;
namespace MySpot.Api.Services
{
    public class ReservationService :IReservationService
    {
        private readonly IWeeklyParkingSpotRepository _weeklyParkingSpotRepository;
        private static IClock _clock ;
  
        public ReservationService(IClock clock,IWeeklyParkingSpotRepository weeklyParkingSpots) 
        {
            _clock = clock;
            _weeklyParkingSpotRepository = weeklyParkingSpots;
        }

        public ReservationDto Get(Guid id) =>
            GetAllWeekly().SingleOrDefault(x => x.Id == id);


        public IEnumerable<ReservationDto> GetAllWeekly()
            => _weeklyParkingSpotRepository.GetAll().SelectMany(x => x.Reservations).Select(x => new ReservationDto
            {
                Id = x.Id,
                ParkingSpotId = x.ParkingSpotId,
                EmployeeName = x.EmployeeName,
                Date = x.Date.Value.Date
            });

        public Guid? Create(CreateReservation command)
        {
            var parkingSpotId = new ParkingSpotId(command.ParkingSpotId);
            var weeklyParkingSpot = _weeklyParkingSpotRepository.Get(parkingSpotId);

            if (weeklyParkingSpot is null)
            {
                return default;
            }

            var reservation = new Reservation(command.ReservationId, command.ParkingSpotId, command.EmployeeName,
                command.LicensePlate, new Date(command.Date));

            weeklyParkingSpot.AddReservation(reservation,new Date(_clock.Current()));
            _weeklyParkingSpotRepository.Update(weeklyParkingSpot);

            return reservation.Id;
        }

        public bool Update(ChangeReservationLicensePlate command)
        {
            var weeklyParkingSpot = GetWeeklyParkingSpotByReservation(command.ReservationId);
            if (weeklyParkingSpot == null)
            {
                return false;
            }
            var reservationId = new ReservationId(command.ReservationId);
            var existingReservation = weeklyParkingSpot.Reservations.SingleOrDefault(x => x.Id == reservationId);

            if (existingReservation.Date.Value <= _clock.Current())
            {
                return false;
            }
            existingReservation.ChangeLicensePlate(command.LicensePlate);
            _weeklyParkingSpotRepository.Update(weeklyParkingSpot);

            return true;
        }

        public bool Delete(DeleteReservation command)
        {
            var weeklyParkingSpot = GetWeeklyParkingSpotByReservation(command.ReservationId);
            if (weeklyParkingSpot is null)
            {
                return false;
            }
            var reservationId = new ReservationId(command.ReservationId);
            var existingReservation = weeklyParkingSpot.Reservations.SingleOrDefault(x => x.Id == reservationId);
            if (existingReservation is null)
            {
                return false;
            }
            weeklyParkingSpot.RemoveReservation(command.ReservationId);
            _weeklyParkingSpotRepository.Delete(weeklyParkingSpot);
            return true;
        }

        private WeeklyParkingSpot GetWeeklyParkingSpotByReservation(ReservationId reservationId) 
            => _weeklyParkingSpotRepository.GetAll().SingleOrDefault(x => x.Reservations.Any(r => r.Id == reservationId));

    }
}
