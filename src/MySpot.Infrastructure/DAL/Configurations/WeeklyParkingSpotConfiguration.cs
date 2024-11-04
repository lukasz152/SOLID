using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySpot.Api.Entities;
using MySpot.Api.ValueObjects;

namespace MySpot.Infrastructure.DAL.Configurations
{
    internal sealed class WeeklyParkingSpotConfiguration : IEntityTypeConfiguration<Api.Entities.WeeklyParkingSpot>
    {
        public void Configure(EntityTypeBuilder<Api.Entities.WeeklyParkingSpot> builder)
        {
            builder.HasKey(x => x.Id); //klucz

            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ParkingSpotId(x));
            builder.Property(x => x.Week)
                .HasConversion(x => x.To.Value, x => new Week(x));
        }
    }
}
