using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.Entities;

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
            builder.Property(x => x.Date)
                .HasConversion(x => x.Value, x => new Date(x));

            builder
                .HasDiscriminator<string>("Type")
                .HasValue<CleaningReservation>(nameof(CleaningReservation))
                .HasValue<VehicleReservation>(nameof(VehicleReservation));
        }
    }
}
