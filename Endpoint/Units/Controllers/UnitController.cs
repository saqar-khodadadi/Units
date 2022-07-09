using Application.Services.Contracts;
using Application.Services.DTOs.AddFactors;
using Application.Services.DTOs.AddUnits;
using Application.Services.DTOs.ChangeUnits;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Units.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly IUnitService _unitService;
        public UnitController(ILogger<UnitController> logger, IUnitService unitService)
        {
            _logger = logger;
            _unitService = unitService;
        }

        #region AddUnits

        [HttpPost]
        public async Task<IActionResult> AddBasicUnit(AddBasicUnitRequest request)
        {
            try
            {
                var res=await _unitService.AddBasicUnitAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMultipleUnit(AddMultipleUnitRequest request)
        {
            try
            {
                var res=await _unitService.AddMultipleUnitAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFormulaUnit(AddFormulaUnitRequest request)
        {
            try
            {
                var res=await _unitService.AddFormulaUnitAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        #endregion

        #region AddFactors

        [HttpPost]
        public async Task<IActionResult> AddMultipleFactor(AddMultipleFactorRequest request)
        {
            try
            {
                var res=await _unitService.AddMultipleFactorAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFormulaFactor(AddFormulaFactorRequest request)
        {
            try
            {
                var res=await _unitService.AddFormulaFactorAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        #endregion


        #region ChangeUnits

        [HttpPost]
        public async Task<ActionResult<ChangeUnitResponse>> ChangeUnit(ChangeUnitRequest request)
        {
            try
            {
                var res=await _unitService.ChangeUnitAsync(request);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest();
            }
        }

        #endregion

    }
}
