﻿// <auto-generated />
using System;
using HouseholdManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HouseholdManager.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230114041634_HouseholdAndLinkTablesSetup")]
    partial class HouseholdAndLinkTablesSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HouseholdManager.Models.Household", b =>
                {
                    b.Property<int>("HouseholdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HouseholdId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("HouseholdId");

                    b.ToTable("Households");
                });

            modelBuilder.Entity("HouseholdManager.Models.Mission", b =>
                {
                    b.Property<int>("MissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MissionId"), 1L, 1);

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<string>("MissionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("MissionId");

                    b.HasIndex("HouseholdId");

                    b.HasIndex("RoomId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("HouseholdManager.Models.Room", b =>
                {
                    b.Property<int>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomId"), 1L, 1);

                    b.Property<int>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoomId");

                    b.HasIndex("HouseholdId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("HouseholdManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HouseholdId")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.HasIndex("HouseholdId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HouseholdManager.Models.Mission", b =>
                {
                    b.HasOne("HouseholdManager.Models.Household", "Household")
                        .WithMany("Missions")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HouseholdManager.Models.Room", "Room")
                        .WithMany("Missions")
                        .HasForeignKey("RoomId");

                    b.Navigation("Household");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("HouseholdManager.Models.Room", b =>
                {
                    b.HasOne("HouseholdManager.Models.Household", "Household")
                        .WithMany("Rooms")
                        .HasForeignKey("HouseholdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Household");
                });

            modelBuilder.Entity("HouseholdManager.Models.User", b =>
                {
                    b.HasOne("HouseholdManager.Models.Household", "Household")
                        .WithMany("Members")
                        .HasForeignKey("HouseholdId");

                    b.Navigation("Household");
                });

            modelBuilder.Entity("HouseholdManager.Models.Household", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Missions");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("HouseholdManager.Models.Room", b =>
                {
                    b.Navigation("Missions");
                });
#pragma warning restore 612, 618
        }
    }
}
