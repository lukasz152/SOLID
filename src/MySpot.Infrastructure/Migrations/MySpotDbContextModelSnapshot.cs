﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySpot.Infrastructure.DAL;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MySpot.Infrastructure.Migrations
{
    [DbContext(typeof(MySpotDbContext))]
    partial class MySpotDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-rc.2.24474.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MySpot.Api.Entities.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ParkingSpotId")
                        .HasColumnType("uuid");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<Guid?>("WeeklyParkingSpotId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("WeeklyParkingSpotId");

                    b.ToTable("Reservation");

                    b.HasDiscriminator<string>("Type").HasValue("Reservation");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MySpot.Api.Entities.WeeklyParkingSpot", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Week")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("WeeklyParkingSpots");
                });

            modelBuilder.Entity("MySpot.Core.Entities.CleaningReservation", b =>
                {
                    b.HasBaseType("MySpot.Api.Entities.Reservation");

                    b.HasDiscriminator().HasValue("CleaningReservation");
                });

            modelBuilder.Entity("MySpot.Core.Entities.VehicleReservation", b =>
                {
                    b.HasBaseType("MySpot.Api.Entities.Reservation");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("VehicleReservation");
                });

            modelBuilder.Entity("MySpot.Api.Entities.Reservation", b =>
                {
                    b.HasOne("MySpot.Api.Entities.WeeklyParkingSpot", null)
                        .WithMany("Reservations")
                        .HasForeignKey("WeeklyParkingSpotId");
                });

            modelBuilder.Entity("MySpot.Api.Entities.WeeklyParkingSpot", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
