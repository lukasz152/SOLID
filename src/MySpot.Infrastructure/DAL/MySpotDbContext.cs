﻿using Microsoft.EntityFrameworkCore;
using MySpot.Api.Entities;

namespace MySpot.Infrastructure.DAL
{
    public sealed class MySpotDbContext :DbContext
    {
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<WeeklyParkingSpot> WeeklyParkingSpot { get; set; }

        public MySpotDbContext(DbContextOptions<MySpotDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            //albo to na dole albo u gory (to u gory wyszukuje wszytskie mapowania w tym assmeblie ktore uzywa ientiotytypeconfigration)
            //modelBuilder.ApplyConfiguration(new ReservationConfigration());
            //modelBuilder.ApplyConfiguration(new WeeklyParkingSpotConfiguration());
        }
    }
}
