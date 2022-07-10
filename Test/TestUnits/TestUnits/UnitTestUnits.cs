

using Application.Services.Contracts;
using Application.Services.DTOs.AddFactors;
using Application.Services.DTOs.AddUnits;
using Application.Services.DTOs.ChangeUnits;
using Application.Services.Services;
using Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestUnits
{

    public class UnitTestUnits : IClassFixture<DependencySetupFixture>
    {
        private ServiceProvider _serviceProvider;
        //private readonly IUnitService unitService;
        public UnitTestUnits(/*IUnitService unitService*/DependencySetupFixture fixture)
        {
            _serviceProvider = fixture.ServiceProvider;
            //_unitService = new UnitService(new UnitDbContext(new DbContextOptions<UnitDbContext>()));
        }
        [Fact]
        public async Task AddBasicUnitTest()
        {
            bool assert;
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service?.AddBasicUnitAsync(new AddBasicUnitRequest()
                {
                    Title = "مول",
                    EnTitle = "mole",
                    Measurment = "مقدار ماده",
                    EnMeasurment = "amount of substance",
                    Symbol = "mol"
                })!;
                assert = result.IsSuccessful;
            }
            Assert.False(!assert, "متد یا مشکل مواجه شد");

        }

        [Fact]
        public async Task AddMultipleUnitTest()
        {
            bool assert;

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service.AddMultipleUnitAsync(new AddMultipleUnitRequest()
            {
                Title = "مگامتر",
                EnTitle = "MegaMeter",
                Symbol = "Mm",
                FactorId = 6,
                ParentId = 1
            });
                assert = result.IsSuccessful;
            }
            Assert.False(!assert, "متد یا مشکل مواجه شد");
        }

        [Fact]
        public async Task AddFormulaUnitTest()
        {
            bool assert;

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service.AddFormulaUnitAsync(new AddFormulaUnitRequest()
                {
                    Title = "!فارنهایت گرم",
                    EnTitle = "TestFarenhiteGram!",
                    Symbol = "Fg",
                    FactorId = 3,
                    ParentId = 2
                });
                assert = result.IsSuccessful;
            }

            Assert.False(!assert, "متد یا مشکل مواجه شد");
        }

        [Fact]
        public async Task AddMultipleFactorTest()
        {
            bool assert;

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service.AddMultipleFactorAsync(new AddMultipleFactorRequest()
                {
                    Title = "میکرون",
                    Value = "0.000001"
                });
                assert = result.IsSuccessful;
            }

            Assert.False(!assert, "متد یا مشکل مواجه شد");
        }

        [Fact]
        public async Task AddFormulaFactorTest()
        {
            bool assert;
            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service.AddFormulaFactorAsync(new AddFormulaFactorRequest()
                {
                    Title = "فرمول تستی",
                    ToValue = "(a*2)-29",
                    ToBase = "(a+29)/5"
                });
                assert = result.IsSuccessful;
            }

            Assert.False(!assert, "متد یا مشکل مواجه شد");
        }

        [Fact]
        public async Task ChangeUnitUnitTest()
        {
            bool assert;

            using (var scope = _serviceProvider.CreateScope())
            {
                var service = scope.ServiceProvider.GetService<IUnitService>();
                var result = await service.ChangeUnitAsync(new ChangeUnitRequest()
                {
                    Value = 18,
                    SourceUnitId = 14,
                    DestinationUnitId = 13
                });
                assert = result.IsSuccessful;
            }

            Assert.False(!assert, "متد یا مشکل مواجه شد");
        }

    }
}
public class DependencySetupFixture
{
    public DependencySetupFixture()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
       var configuration = builder.Build();


        var serviceCollection = new ServiceCollection();
        serviceCollection.AddDbContext<UnitDbContext>(option =>
            option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        serviceCollection.AddTransient<IUnitService, UnitService>();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public ServiceProvider ServiceProvider { get; private set; }
}