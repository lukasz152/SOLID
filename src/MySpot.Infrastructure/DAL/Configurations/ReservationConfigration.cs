using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations
{
    internal sealed class ReservationConfigration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder) 
        {
            builder.HasKey(x => x.Id); //klucz 
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ReservationId(x));  // z guid na reservationId
            builder.Property(x => x.ParkingSpotId)
                .HasConversion(x => x.Value, x => new ParkingSpotId(x));
            builder.Property(x => x.EmployeeName)
                .HasConversion(x => x.Value, x => new EmployeeName(x));
            builder.Property(x => x.LicensePlate)
                .HasConversion(x => x.Value, x => new LicensePlate(x));
            builder.Property(x => x.Date)
                .HasConversion(x => x.Value, x => new Date(x));
        }
    }
}
