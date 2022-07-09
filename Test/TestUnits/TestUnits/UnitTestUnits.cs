

using Application.Services.Contracts;
using Application.Services.DTOs.AddUnits;
using Application.Services.Services;

namespace TestUnits
{
    public class UnitTestUnits
    {
        private readonly IUnitService _unitService;
        public UnitTestUnits(IUnitService unitService)
        {
            _unitService = unitService;
        }
        [Fact]
        public async Task AddBasicUnitTest()
        {
            var result =await _unitService.AddBasicUnitAsync(new AddBasicUnitRequest()
            {
                Title = "مول",
                EnTitle = "mole",
                Measurment = "مقدار ماده",
                EnMeasurment = "amount of substance",
                Symbol = "mol"
            });

            Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        [Fact]
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

            Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        }

        //[Fact]
        //public async Task AddFormulaUnitTest()
        //{
        //    var result = await _unitService.AddFormulaUnitAsync(new AddFormulaUnitRequest()
        //    {
        //        Title = "مول",
        //        EnTitle = "mole",
        //        Measurment = "مقدار ماده",
        //        EnMeasurment = "amount of substance",
        //        Symbol = "mol"
        //    });

        //    Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        //}

        //[Fact]
        //public async Task AddBasicUnitTest()
        //{
        //    var result = await _unitService.AddBasicUnitAsync(new AddBasicUnitRequest()
        //    {
        //        Title = "مول",
        //        EnTitle = "mole",
        //        Measurment = "مقدار ماده",
        //        EnMeasurment = "amount of substance",
        //        Symbol = "mol"
        //    });

        //    Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        //}

        //[Fact]
        //public async Task AddBasicUnitTest()
        //{
        //    var result = await _unitService.AddBasicUnitAsync(new AddBasicUnitRequest()
        //    {
        //        Title = "مول",
        //        EnTitle = "mole",
        //        Measurment = "مقدار ماده",
        //        EnMeasurment = "amount of substance",
        //        Symbol = "mol"
        //    });

        //    Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        //}

        //[Fact]
        //public async Task AddBasicUnitTest()
        //{
        //    var result = await _unitService.AddBasicUnitAsync(new AddBasicUnitRequest()
        //    {
        //        Title = "مول",
        //        EnTitle = "mole",
        //        Measurment = "مقدار ماده",
        //        EnMeasurment = "amount of substance",
        //        Symbol = "mol"
        //    });

        //    Assert.False(result.IsSuccessful, "متد یا مشکل مواجه شد");
        //}

    }
}
