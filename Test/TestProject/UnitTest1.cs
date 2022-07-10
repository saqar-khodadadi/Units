using Application.Services.Contracts;
using Application.Services.DTOs.AddFactors;
using Application.Services.DTOs.AddUnits;
using Application.Services.DTOs.ChangeUnits;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUnitService _unitService;
        public UnitTest1(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [TestMethod]
        public async Task AddBasicUnitTest()
        {
            var result = await _unitService.AddBasicUnitAsync(new AddBasicUnitRequest()
            {
                Title = "مول",
                EnTitle = "mole",
                Measurment = "مقدار ماده",
                EnMeasurment = "amount of substance",
                Symbol = "mol"
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [TestMethod]
        public async Task AddMultipleUnitTest()
        {
            var result = await _unitService.AddMultipleUnitAsync(new AddMultipleUnitRequest()
            {
                Title = "مگامتر",
                EnTitle = "MegaMeter",
                Symbol = "Mm",
                FactorId = 6,
                ParentId = 1
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [TestMethod]
        public async Task AddFormulaUnitTest()
        {
            var result = await _unitService.AddFormulaUnitAsync(new AddFormulaUnitRequest()
            {
                Title = "TestFarenhiteGram!",
                EnTitle = "!فارنهایت گرم",
                Symbol = "Fg",
                FactorId = 3,
                ParentId = 2
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [TestMethod]
        public async Task AddMultipleFactorTest()
        {
            var result = await _unitService.AddMultipleFactorAsync(new AddMultipleFactorRequest()
            {
                Title = "میکرون",
                Value = "0.000001"
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [TestMethod]
        public async Task AddFormulaFactorTest()
        {
            var result = await _unitService.AddFormulaFactorAsync(new AddFormulaFactorRequest()
            {
                Title = "TestFormula",
                ToValue = "(a*2)-29",
                ToBase = "(a+29)/5"
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [TestMethod]
        public async Task ChangeUnitUnitTest()
        {
            var result = await _unitService.ChangeUnitAsync(new ChangeUnitRequest()
            {
                Value = 18,
                SourceUnitId = 14,
                DestinationUnitId = 13
            });

            Assert.IsFalse(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }
    }
}
