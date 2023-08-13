﻿// <auto-generated />
using System;
using BookingAndReservationApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookingAndReservationApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230813094655_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.6.23329.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookingAndReservationApi.Models.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdvertisementUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementUserId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<DateTime>("BookDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BookingUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndBookingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartBookingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("BookingUserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AdvertisementId")
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewerUserId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementId");

                    b.HasIndex("ReviewerUserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Advertisement", b =>
                {
                    b.HasOne("BookingAndReservationApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("AdvertisementUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Booking", b =>
                {
                    b.HasOne("BookingAndReservationApi.Models.Advertisement", "Advertisement")
                        .WithMany()
                        .HasForeignKey("AdvertisementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookingAndReservationApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("BookingUserId");

                    b.Navigation("Advertisement");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Reviewer", b =>
                {
                    b.HasOne("BookingAndReservationApi.Models.Advertisement", null)
                        .WithMany("Reviewers")
                        .HasForeignKey("AdvertisementId");

                    b.HasOne("BookingAndReservationApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("ReviewerUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookingAndReservationApi.Models.Advertisement", b =>
                {
                    b.Navigation("Reviewers");
                });
#pragma warning restore 612, 618
        }
    }
}
