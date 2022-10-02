﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211219220210_m4")]
    partial class m4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.GameConfig", b =>
                {
                    b.Property<int>("GameConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardSizeX")
                        .HasColumnType("int");

                    b.Property<int>("BoardSizeY")
                        .HasColumnType("int");

                    b.Property<string>("ConfigName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("EShipTouchRule")
                        .HasColumnType("int");

                    b.HasKey("GameConfigId");

                    b.ToTable("GameConfigs");
                });

            modelBuilder.Entity("Domain.GameSave", b =>
                {
                    b.Property<int>("GameSaveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstGameBoard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameConfigId")
                        .HasColumnType("int");

                    b.Property<int>("GameCurrentPlayerNumber")
                        .HasColumnType("int");

                    b.Property<int>("GameMovesNumber")
                        .HasColumnType("int");

                    b.Property<int>("GamePhase")
                        .HasColumnType("int");

                    b.Property<string>("SaveName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("SecondGameBoard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameSaveId");

                    b.HasIndex("GameConfigId");

                    b.ToTable("GameSaves");
                });

            modelBuilder.Entity("Domain.GameShip", b =>
                {
                    b.Property<int>("GameShipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Coordinates")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GameSaveId")
                        .HasColumnType("int");

                    b.Property<int?>("GameShipConfigId")
                        .HasColumnType("int");

                    b.Property<int>("IsPlaced")
                        .HasColumnType("int");

                    b.Property<int>("Player")
                        .HasColumnType("int");

                    b.HasKey("GameShipId");

                    b.HasIndex("GameSaveId");

                    b.HasIndex("GameShipConfigId");

                    b.ToTable("GameShip");
                });

            modelBuilder.Entity("Domain.GameShipConfig", b =>
                {
                    b.Property<int>("GameShipConfigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GameConfigId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("ShipName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ShipSizeX")
                        .HasColumnType("int");

                    b.Property<int>("ShipSizeY")
                        .HasColumnType("int");

                    b.HasKey("GameShipConfigId");

                    b.HasIndex("GameConfigId");

                    b.ToTable("GameShipConfig");
                });

            modelBuilder.Entity("Domain.GameSave", b =>
                {
                    b.HasOne("Domain.GameConfig", "GameConfig")
                        .WithMany("GameSaves")
                        .HasForeignKey("GameConfigId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("GameConfig");
                });

            modelBuilder.Entity("Domain.GameShip", b =>
                {
                    b.HasOne("Domain.GameSave", "GameSave")
                        .WithMany("GameShips")
                        .HasForeignKey("GameSaveId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.GameShipConfig", "GameShipConfigs")
                        .WithMany("GameShips")
                        .HasForeignKey("GameShipConfigId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("GameSave");

                    b.Navigation("GameShipConfigs");
                });

            modelBuilder.Entity("Domain.GameShipConfig", b =>
                {
                    b.HasOne("Domain.GameConfig", "GameConfig")
                        .WithMany("ShipConfigInGameConfigs")
                        .HasForeignKey("GameConfigId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("GameConfig");
                });

            modelBuilder.Entity("Domain.GameConfig", b =>
                {
                    b.Navigation("GameSaves");

                    b.Navigation("ShipConfigInGameConfigs");
                });

            modelBuilder.Entity("Domain.GameSave", b =>
                {
                    b.Navigation("GameShips");
                });

            modelBuilder.Entity("Domain.GameShipConfig", b =>
                {
                    b.Navigation("GameShips");
                });
#pragma warning restore 612, 618
        }
    }
}
