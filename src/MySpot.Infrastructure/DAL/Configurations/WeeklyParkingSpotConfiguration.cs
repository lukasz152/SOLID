using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;
using MySpot.Core.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations
{
    internal sealed class WeeklyParkingSpotConfiguration : IEntityTypeConfiguration<WeeklyParkingSpot>
    {
        public void Configure(EntityTypeBuilder<WeeklyParkingSpot> builder)
        {
            builder.HasKey(x => x.Id); //klucz

            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ParkingSpotId(x));
            builder.Property(x => x.Week)
                .HasConversion(x => x.To.Value, x => new Week(x));
            builder.Property(x => x.Capacity)
                .IsRequired()
                .HasConversion(x => x.Value, x => new Capacity(x));
            builder.Property(x => x.Capacity)
            .IsRequired()
            .HasConversion(x => x.Value, x => new(x));
        }
    }
}
