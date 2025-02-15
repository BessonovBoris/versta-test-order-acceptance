﻿// <auto-generated />
using DataBase.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataBase.Migrations.UserRepositoryMigrations
{
    [DbContext(typeof(UserRepository))]
    partial class UserRepositoryModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Application.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Andrew",
                            Password = "AndrewPassword"
                        },
                        new
                        {
                            UserId = 2,
                            Name = "Tom",
                            Password = "TomPassword"
                        },
                        new
                        {
                            UserId = 3,
                            Name = "Bob",
                            Password = "BobPassword"
                        },
                        new
                        {
                            UserId = 4,
                            Name = "Sam",
                            Password = "SamPassword"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
