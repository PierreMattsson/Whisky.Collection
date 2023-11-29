﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhiskyCollectionPersistence.DatabaseContext;

#nullable disable

namespace WhiskyCollectionPersistence.Migrations
{
    [DbContext(typeof(MyWhiskyDatabaseContext))]
    partial class MyWhiskyDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("Whisky.Collection.Domain.MyCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("TasteDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("WhiskyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WhiskyId");

                    b.ToTable("myCollections");
                });

            modelBuilder.Entity("Whisky.Collection.Domain.MyPurchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PurchaseCost")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PurchaseDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("WhiskyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WhiskyId");

                    b.ToTable("myPurchase");
                });

            modelBuilder.Entity("Whisky.Collection.Domain.MyWhisky", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AlkoholProcent")
                        .HasColumnType("REAL");

                    b.Property<int>("BottleContentMilliliter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BottleDescription")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProducerName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("WhiskyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WhiskyYearStatement")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("MyWhiskies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlkoholProcent = 40.0,
                            BottleContentMilliliter = 700,
                            BottleDescription = "Highland Single Malt Scotch Whisky",
                            CreatedDate = new DateTime(2023, 11, 29, 16, 33, 29, 685, DateTimeKind.Local).AddTicks(7865),
                            ProducerName = "Macallan",
                            UpdatedDate = new DateTime(2023, 11, 29, 16, 33, 29, 685, DateTimeKind.Local).AddTicks(7912),
                            WhiskyName = "Double Cask",
                            WhiskyYearStatement = 12
                        });
                });

            modelBuilder.Entity("Whisky.Collection.Domain.MyCollection", b =>
                {
                    b.HasOne("Whisky.Collection.Domain.MyWhisky", "Whisky")
                        .WithMany()
                        .HasForeignKey("WhiskyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Whisky");
                });

            modelBuilder.Entity("Whisky.Collection.Domain.MyPurchase", b =>
                {
                    b.HasOne("Whisky.Collection.Domain.MyWhisky", "Whisky")
                        .WithMany()
                        .HasForeignKey("WhiskyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Whisky");
                });
#pragma warning restore 612, 618
        }
    }
}
