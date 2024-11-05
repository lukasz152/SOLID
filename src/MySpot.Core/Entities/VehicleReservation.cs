using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities
{
    public sealed class VehicleReservation : Reservation
    {
        public EmployeeName EmployeeName { get; private set; }
        public LicencePlate LicensePlate { get; private set; }

        private VehicleReservation() { }

        public VehicleReservation(ReservationId id, ParkingSpotId parkingSpotId, 
            EmployeeName employeeName, LicencePlate licensePlate, Capacity capacity, Date date) 
            : base(id, parkingSpotId, capacity,date)
        {
            EmployeeName= employeeName;
            ChangeLicensePlate(licensePlate);
        }

        public void ChangeLicensePlate(LicencePlate licensePlate)
            => LicensePlate = licensePlate;
    }
}
