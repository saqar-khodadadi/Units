﻿// <auto-generated />
using System;
using Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.DataAccess.Migrations
{
    [DbContext(typeof(UnitDbContext))]
    partial class UnitDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Domain.Factor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("KindId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("ToBase")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ToValue")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("KindId");

                    b.ToTable("Factor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 1,
                            Title = "پایه",
                            ToBase = "a",
                            ToValue = "a"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 2,
                            Title = "کیلو",
                            ToBase = "a*1000",
                            ToValue = "a/1000"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 3,
                            Title = "فارنهایت",
                            ToBase = "(a − 32) × 5/9",
                            ToValue = "(a * 9/5) + 32"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 2,
                            Title = "میلی",
                            ToBase = "a*0.001",
                            ToValue = "a/0.001"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 2,
                            Title = "ثانتی",
                            ToBase = "a*0.01",
                            ToValue = "a/0.01"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 2,
                            Title = "مگا",
                            ToBase = "a*1000000",
                            ToValue = "a/1000000"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            KindId = 2,
                            Title = "کلوین",
                            ToBase = "a − 273.15",
                            ToValue = "a + 273.15"
                        });
                });

            modelBuilder.Entity("Core.Domain.Kind", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Kind");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "پایه"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "ضریب دار"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "فرمول دار"
                        });
                });

            modelBuilder.Entity("Core.Domain.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("EnMeasurment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnTitle")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<int>("FactorId")
                        .HasColumnType("int");

                    b.Property<string>("Measurment")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.HasKey("Id");

                    b.HasIndex("FactorId");

                    b.HasIndex("ParentId");

                    b.ToTable("Unit");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Length",
                            EnTitle = "Meter",
                            FactorId = 1,
                            Measurment = "طول",
                            Symbol = "m",
                            Title = "متر"
                        },
                        new
                        {
                            Id = 2,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Mass",
                            EnTitle = "Gram",
                            FactorId = 1,
                            Measurment = "جرم",
                            Symbol = "g",
                            Title = "گرم"
                        },
                        new
                        {
                            Id = 3,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "electric current",
                            EnTitle = "Ampere",
                            FactorId = 1,
                            Measurment = "جریان الکترونیکی",
                            Symbol = "A",
                            Title = "آمپر"
                        },
                        new
                        {
                            Id = 4,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Time",
                            EnTitle = "Second",
                            FactorId = 1,
                            Measurment = "زمان",
                            Symbol = "S",
                            Title = "ثانیه"
                        },
                        new
                        {
                            Id = 5,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "numeration",
                            EnTitle = "Each",
                            FactorId = 1,
                            Measurment = "شمارش",
                            Symbol = "E",
                            Title = "عدد"
                        },
                        new
                        {
                            Id = 6,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Temperature",
                            EnTitle = "Celsius",
                            FactorId = 1,
                            Measurment = "دما",
                            Symbol = "C",
                            Title = "سلسیوس"
                        },
                        new
                        {
                            Id = 7,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Length",
                            EnTitle = "Milimeter",
                            FactorId = 4,
                            Measurment = "طول",
                            ParentId = 1,
                            Symbol = "mm",
                            Title = "میلی متر"
                        },
                        new
                        {
                            Id = 8,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Length",
                            EnTitle = "Centimeter",
                            FactorId = 5,
                            Measurment = "متر",
                            ParentId = 1,
                            Symbol = "cm",
                            Title = "ثانتی متر"
                        },
                        new
                        {
                            Id = 9,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Length",
                            EnTitle = "Kilometer",
                            FactorId = 2,
                            Measurment = "متر",
                            ParentId = 1,
                            Symbol = "km",
                            Title = "کیلومتر"
                        },
                        new
                        {
                            Id = 10,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Mass",
                            EnTitle = "Milligram",
                            FactorId = 4,
                            Measurment = "جرم",
                            ParentId = 2,
                            Symbol = "mg",
                            Title = "میلی گرم"
                        },
                        new
                        {
                            Id = 11,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Mass",
                            EnTitle = "Kilogram",
                            FactorId = 2,
                            Measurment = "جرم",
                            ParentId = 2,
                            Symbol = "kg",
                            Title = "کیلوگرم"
                        },
                        new
                        {
                            Id = 12,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Mass",
                            EnTitle = "Tonne",
                            FactorId = 6,
                            Measurment = "جرم",
                            ParentId = 2,
                            Symbol = "ton",
                            Title = "تن"
                        },
                        new
                        {
                            Id = 13,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Temperature",
                            EnTitle = "Kelvin",
                            FactorId = 7,
                            Measurment = "دما",
                            ParentId = 6,
                            Symbol = "K",
                            Title = "کلوین"
                        },
                        new
                        {
                            Id = 14,
                            CreationDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnMeasurment = "Temperature",
                            EnTitle = "Fahrenheit",
                            FactorId = 3,
                            Measurment = "دما",
                            ParentId = 6,
                            Symbol = "F",
                            Title = "فارنهایت"
                        });
                });

            modelBuilder.Entity("Core.Domain.Factor", b =>
                {
                    b.HasOne("Core.Domain.Kind", "Kind")
                        .WithMany("Factors")
                        .HasForeignKey("KindId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kind");
                });

            modelBuilder.Entity("Core.Domain.Unit", b =>
                {
                    b.HasOne("Core.Domain.Factor", "Factor")
                        .WithMany("Units")
                        .HasForeignKey("FactorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Unit", "ParentUnit")
                        .WithMany("ChildUnits")
                        .HasForeignKey("ParentId");

                    b.Navigation("Factor");

                    b.Navigation("ParentUnit");
                });

            modelBuilder.Entity("Core.Domain.Factor", b =>
                {
                    b.Navigation("Units");
                });

            modelBuilder.Entity("Core.Domain.Kind", b =>
                {
                    b.Navigation("Factors");
                });

            modelBuilder.Entity("Core.Domain.Unit", b =>
                {
                    b.Navigation("ChildUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
