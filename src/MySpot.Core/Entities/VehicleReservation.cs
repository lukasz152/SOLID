using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities
{
    public sealed class VehicleReservation : Reservation
    {
        public UserId UserId { get; private set; }
        public EmployeeName EmployeeName { get; private set; }
        public LicencePlate LicencePlate { get; private set; }

        private VehicleReservation() { }

        public VehicleReservation(ReservationId id, UserId userId, EmployeeName employeeName, 
            LicencePlate licensePlate, Capacity capacity, Date date) 
            : base(id, capacity,date)
        {
            UserId = userId;
            EmployeeName = employeeName;
            LicencePlate = licensePlate;
        }

        public void ChangeLicensePlate(LicencePlate licensePlate)
            => LicencePlate = licensePlate;
    }
}
