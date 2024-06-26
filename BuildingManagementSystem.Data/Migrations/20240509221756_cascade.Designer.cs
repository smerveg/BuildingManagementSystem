﻿// <auto-generated />
using System;
using BuildingManagementSystem.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BuildingManagementSystem.Data.Migrations
{
    [DbContext(typeof(BMSContext))]
    [Migration("20240509221756_cascade")]
    partial class cascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Building", b =>
                {
                    b.Property<int>("BuildingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BuildingID");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.ProductStorage", b =>
                {
                    b.Property<int>("ProductStorageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductID1")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StorageID")
                        .HasColumnType("int");

                    b.Property<int?>("StorageID1")
                        .HasColumnType("int");

                    b.HasKey("ProductStorageID");

                    b.HasIndex("ProductID");

                    b.HasIndex("ProductID1");

                    b.HasIndex("StorageID");

                    b.HasIndex("StorageID1");

                    b.ToTable("ProductStorage");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Room", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoomID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Storage", b =>
                {
                    b.Property<int>("StorageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuildingID")
                        .HasColumnType("int");

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StorageID");

                    b.HasIndex("BuildingID");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.ProductStorage", b =>
                {
                    b.HasOne("BuildingManagementSystem.Data.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagementSystem.Data.Entities.Product", null)
                        .WithMany("ProductStorages")
                        .HasForeignKey("ProductID1");

                    b.HasOne("BuildingManagementSystem.Data.Entities.Storage", null)
                        .WithMany()
                        .HasForeignKey("StorageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BuildingManagementSystem.Data.Entities.Storage", null)
                        .WithMany("ProductStorages")
                        .HasForeignKey("StorageID1");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Room", b =>
                {
                    b.HasOne("BuildingManagementSystem.Data.Entities.Building", "Building")
                        .WithMany("Rooms")
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Storage", b =>
                {
                    b.HasOne("BuildingManagementSystem.Data.Entities.Building", "Building")
                        .WithMany("Storages")
                        .HasForeignKey("BuildingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Building", b =>
                {
                    b.Navigation("Rooms");

                    b.Navigation("Storages");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Product", b =>
                {
                    b.Navigation("ProductStorages");
                });

            modelBuilder.Entity("BuildingManagementSystem.Data.Entities.Storage", b =>
                {
                    b.Navigation("ProductStorages");
                });
#pragma warning restore 612, 618
        }
    }
}
