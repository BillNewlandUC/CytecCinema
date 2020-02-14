﻿// <auto-generated />
using System;
using CytecCinema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CytecCinema.Migrations
{
    [DbContext(typeof(CinemaContext))]
    [Migration("20200214092956_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CytecCinema.Models.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ShowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TicketsBought")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShowingId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("CytecCinema.Models.Showing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShowingAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Showings");
                });

            modelBuilder.Entity("CytecCinema.Models.Booking", b =>
                {
                    b.HasOne("CytecCinema.Models.Showing", "Showing")
                        .WithMany()
                        .HasForeignKey("ShowingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}