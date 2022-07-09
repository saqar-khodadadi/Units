using Core.Domain;
using Infrastructure.DataAccess.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Context
{
    public class UnitDbContext : DbContext
    {

        public UnitDbContext(DbContextOptions option) : base(option)
        {
        }
        public DbSet<Factor>? Factor { get; set; }
        public DbSet<Kind>? Kind { get; set; }
        public DbSet<Unit>? Unit { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FactorConfiguration());
            modelBuilder.ApplyConfiguration(new KindConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());

            modelBuilder.Entity<Factor>().HasData(new List<Factor>()
            {
                new Factor
                {
                    Id = 1,
                    Title = "پایه",
                    KindId = 1,
                    ToValue = "a",
                    ToBase = "a"
                },
                new Factor
                {
                    Id = 2,
                    Title = "کیلو",
                    KindId = 2,
                    ToValue = "a/1000",
                    ToBase = "a*1000"
                },
                new Factor
                {
                    Id = 3,
                    Title = "فارنهایت",
                    KindId = 3,
                    ToValue = "(a * 9/5) + 32",
                    ToBase = "(a - 32) * 5/9"
                },
                new Factor()
                {
                    Id = 4,
                    Title = "میلی",
                    KindId = 2,
                    ToValue = "a/0.001",
                    ToBase = "a*0.001"
                },
                new Factor()
                {
                    Id = 5,
                    Title = "ثانتی",
                    KindId = 2,
                    ToValue = "a/0.01",
                    ToBase = "a*0.01"
                },
                new Factor()
                {
                    Id = 6,
                    Title = "مگا",
                    KindId = 2,
                    ToValue = "a/1000000",
                    ToBase = "a*1000000"
                },
                new Factor()
                {
                    Id = 7,
                    Title = "کلوین",
                    KindId = 2,
                    ToValue = "a + 273.15",
                    ToBase = "a - 273.15"
                },
            });
            modelBuilder.Entity<Kind>().HasData(new List<Kind>()
            {
                new Kind
                {
                    Id = 1,
                    Title = "پایه"
                },
                new Kind
                {
                    Id = 2,
                    Title = "ضریب دار"
                },
                new Kind
                {
                    Id = 3,
                    Title = "فرمول دار"
                }
            });
            modelBuilder.Entity<Unit>().HasData(new List<Unit>()
            {
                new Unit
                {
                    Id = 1,
                    Title ="متر" ,
                    EnTitle = "Meter",
                    Symbol ="m" ,
                    Measurment ="طول" ,
                    EnMeasurment = "Length",
                    FactorId = 1
                },
                new Unit
                {
                    Id = 2,
                    Title ="گرم" ,
                    EnTitle = "Gram",
                    Symbol ="g" ,
                    Measurment ="جرم" ,
                    EnMeasurment = "Mass",
                    FactorId = 1
                },
                new Unit
                {
                    Id = 3,
                    Title ="آمپر" ,
                    EnTitle = "Ampere",
                    Symbol ="A" ,
                    Measurment ="جریان الکترونیکی" ,
                    EnMeasurment = "electric current",
                    FactorId = 1
                },
                new Unit
                {
                    Id = 4,
                    Title ="ثانیه" ,
                    EnTitle = "Second",
                    Symbol ="S" ,
                    Measurment ="زمان" ,
                    EnMeasurment = "Time",
                    FactorId = 1
                },
                new Unit
                {
                    Id = 5,
                    Title ="عدد" ,
                    EnTitle = "Each",
                    Symbol ="E" ,
                    Measurment ="شمارش" ,
                    EnMeasurment ="numeration" ,
                    FactorId = 1
                },
                new Unit
                {
                    Id = 6,
                    Title ="سلسیوس" ,
                    EnTitle = "Celsius",
                    Symbol ="C" ,
                    Measurment ="دما" ,
                    EnMeasurment = "Temperature",
                    FactorId = 1
                },
                new Unit
                {
                    Id = 7,
                    Title ="میلی متر" ,
                    EnTitle = "Milimeter",
                    Symbol ="mm" ,
                    Measurment ="طول" ,
                    EnMeasurment = "Length",
                    FactorId = 4,
                    ParentId = 1
                },
                new Unit
                {
                    Id = 8,
                    Title ="ثانتی متر" ,
                    EnTitle = "Centimeter",
                    Symbol ="cm" ,
                    Measurment ="متر" ,
                    EnMeasurment = "Length",
                    FactorId = 5,
                    ParentId = 1
                },
                new Unit
                {
                    Id = 9,
                    Title ="کیلومتر" ,
                    EnTitle = "Kilometer",
                    Symbol ="km" ,
                    Measurment ="متر" ,
                    EnMeasurment = "Length",
                    FactorId = 2,
                    ParentId = 1
                },
                new Unit
                {
                    Id = 10,
                    Title ="میلی گرم" ,
                    EnTitle = "Milligram",
                    Symbol ="mg" ,
                    Measurment ="جرم" ,
                    EnMeasurment = "Mass",
                    FactorId = 4,
                    ParentId = 2
                },
                new Unit
                {
                    Id = 11,
                    Title ="کیلوگرم" ,
                    EnTitle = "Kilogram",
                    Symbol ="kg" ,
                    Measurment ="جرم" ,
                    EnMeasurment = "Mass",
                    FactorId = 2,
                    ParentId = 2
                },
                new Unit
                {
                    Id = 12,
                    Title ="تن" ,
                    EnTitle = "Tonne",
                    Symbol ="ton" ,
                    Measurment ="جرم" ,
                    EnMeasurment = "Mass",
                    FactorId = 6,
                    ParentId = 2
                },
                new Unit
                {
                    Id = 13,
                    Title ="کلوین" ,
                    EnTitle = "Kelvin",
                    Symbol ="K" ,
                    Measurment ="دما" ,
                    EnMeasurment = "Temperature",
                    FactorId = 7,
                    ParentId = 6
                },
                new Unit
                {
                    Id = 14,
                    Title ="فارنهایت" ,
                    EnTitle = "Fahrenheit",
                    Symbol ="F" ,
                    Measurment ="دما" ,
                    EnMeasurment = "Temperature",
                    FactorId = 3,
                    ParentId = 6
                }
            });
        }
    }
}
