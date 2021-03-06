﻿// <auto-generated />
using System;
using ASC.Online.AuctionApp.MockDataSeed.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ASC.Online.AuctionApp.MockDataSeed.Migrations
{
    [DbContext(typeof(AuctionContext))]
    [Migration("20201208172928_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ASC.Online.AuctionApp.SessionSetup.DataAccess.Models.Sessions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedMemberId")
                        .HasColumnType("bigint");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ModifiedMemberId")
                        .HasColumnType("bigint");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.Property<DateTime>("SessionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SessionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SessionStatus")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "Jaimy Solovin",
                            CreatedDate = new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedMemberId = 1L,
                            ModifiedBy = "Jaimy Solovin",
                            ModifiedDate = new DateTime(2020, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ModifiedMemberId = 1L,
                            NumberOfItems = 2,
                            SessionEndDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionName = "Mistory Hunt",
                            SessionStartDate = new DateTime(2020, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SessionStatus = "Pending"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
