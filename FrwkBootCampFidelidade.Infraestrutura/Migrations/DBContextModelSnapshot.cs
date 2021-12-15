﻿// <auto-generated />
using System;
using FrwkBootCampFidelidade.Infraestrutura.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FrwkBootCampFidelidade.Infraestrutura.Data.Migrations
{
    [DbContext(typeof(DBContext))]
    partial class DBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.BonificationContext.Entities.Bonification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<float>("ScoreQuantity")
                        .HasColumnType("real");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Bonification");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            OrderId = 1,
                            ScoreQuantity = 52f,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            Date = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            OrderId = 2,
                            ScoreQuantity = 61.25f,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.ExtractContext.Entities.RansomHistoryStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RansomId")
                        .HasColumnType("int");

                    b.Property<int>("RansomStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RansomId");

                    b.HasIndex("RansomStatusId");

                    b.ToTable("RansomHistoryStatus");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<double>("TotalValue")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "02563215479",
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            StoreId = 1,
                            TotalValue = 658.96002197265625,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            CPF = "65989847894",
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            StoreId = 1,
                            TotalValue = 1698.6600341796875,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            UserId = 1
                        });
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Observation = "Medicamento X.1",
                            OrderId = 1,
                            ProductId = 1,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            Observation = "Medicamento X.2",
                            OrderId = 1,
                            ProductId = 2,
                            Quantity = 15
                        },
                        new
                        {
                            Id = 3,
                            Observation = "Medicamento X.3",
                            OrderId = 1,
                            ProductId = 3,
                            Quantity = 25
                        },
                        new
                        {
                            Id = 4,
                            Observation = "Medicamento Y.1",
                            OrderId = 2,
                            ProductId = 4,
                            Quantity = 8
                        },
                        new
                        {
                            Id = 5,
                            Observation = "Medicamento Y.2",
                            OrderId = 2,
                            ProductId = 5,
                            Quantity = 9
                        },
                        new
                        {
                            Id = 6,
                            Observation = "Medicamento Y.3",
                            OrderId = 2,
                            ProductId = 6,
                            Quantity = 10
                        });
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.RansomContext.Entities.Ransom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Agency")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Amount")
                        .HasColumnType("bigint");

                    b.Property<string>("BankAccountNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BankNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beneficiary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CPF")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Operation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PixKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PixKeyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime2");

                    b.Property<long>("WalletId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Ransom");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.RansomContext.Entities.RansomStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RansomStatus");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.WalletContext.Entities.Wallet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DrugstoreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WalletTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WalletTypeId");

                    b.ToTable("Wallet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 50f,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            DrugstoreId = 1,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WalletTypeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 150f,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            DrugstoreId = 1,
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WalletTypeId = 2
                        });
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.WalletContext.Entities.WalletType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WalletType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            Name = "Pontos",
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified),
                            Name = "Dinheiro",
                            UpdatedAt = new DateTime(2021, 12, 13, 15, 45, 23, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.BonificationContext.Entities.Bonification", b =>
                {
                    b.HasOne("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.ExtractContext.Entities.RansomHistoryStatus", b =>
                {
                    b.HasOne("FrwkBootCampFidelidade.Dominio.RansomContext.Entities.Ransom", "Ransom")
                        .WithMany()
                        .HasForeignKey("RansomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FrwkBootCampFidelidade.Dominio.RansomContext.Entities.RansomStatus", "RansomStatus")
                        .WithMany()
                        .HasForeignKey("RansomStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ransom");

                    b.Navigation("RansomStatus");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.OrderItem", b =>
                {
                    b.HasOne("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.WalletContext.Entities.Wallet", b =>
                {
                    b.HasOne("FrwkBootCampFidelidade.Dominio.WalletContext.Entities.WalletType", "WalletType")
                        .WithMany()
                        .HasForeignKey("WalletTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WalletType");
                });

            modelBuilder.Entity("FrwkBootCampFidelidade.Dominio.OrderContext.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
