﻿// <auto-generated />
using System;
using DataBase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations
{
    [DbContext(typeof(OrderRepository))]
    partial class OrderRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OrderId"));

                    b.Property<double>("CargoWeightKg")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("PickupDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ReceiverAddress")
                        .HasColumnType("text");

                    b.Property<string>("ReceiverCity")
                        .HasColumnType("text");

                    b.Property<string>("SenderAddress")
                        .HasColumnType("text");

                    b.Property<string>("SenderCity")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CargoWeightKg = 0.5,
                            PickupDate = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            ReceiverAddress = "Popova, 5",
                            ReceiverCity = "Moscow",
                            SenderAddress = "Kolmogorov, 11",
                            SenderCity = "Saint-Petersburg",
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            CargoWeightKg = 0.5,
                            PickupDate = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            ReceiverAddress = "Kronverskiy, 10",
                            ReceiverCity = "Voronezh",
                            SenderAddress = "Kolmogorov, 11",
                            SenderCity = "Saint-Petersburg",
                            UserId = 1
                        },
                        new
                        {
                            OrderId = 3,
                            CargoWeightKg = 1.0,
                            PickupDate = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            ReceiverAddress = "Tutova, 1",
                            ReceiverCity = "Saint-Petersburg",
                            SenderAddress = "Petrushka, 5",
                            SenderCity = "Novgorod",
                            UserId = 3
                        },
                        new
                        {
                            OrderId = 4,
                            CargoWeightKg = 1.2,
                            PickupDate = new DateTime(2025, 2, 7, 0, 0, 0, 0, DateTimeKind.Utc),
                            ReceiverAddress = "Tamova, 9",
                            ReceiverCity = "Norilsk",
                            SenderAddress = "Retrogradka, 90",
                            SenderCity = "Tula",
                            UserId = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
