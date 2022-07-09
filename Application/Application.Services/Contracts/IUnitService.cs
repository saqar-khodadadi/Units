using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Services.DTOs.AddFactors;
using Application.Services.DTOs.AddUnits;
using Application.Services.DTOs.ChangeUnits;

namespace Application.Services.Contracts
{
    public interface IUnitService
    {
        #region AddUnits
        Task<AddBasicUnitResponse> AddBasicUnitAsync(AddBasicUnitRequest request);
        Task<AddMultipleUnitResponse> AddMultipleUnitAsync(AddMultipleUnitRequest request);
        Task<AddFormulaUnitResponse> AddFormulaUnitAsync(AddFormulaUnitRequest request);
        #endregion

        #region AddFactors
        Task<AddMultipleFactorResponse> AddMultipleFactorAsync(AddMultipleFactorRequest request);
        Task<AddFormulaFactorResponse> AddFormulaFactorAsync(AddFormulaFactorRequest request);

        #endregion


        #region ChangeUnits

        Task<ChangeUnitResponse> ChangeUnitAsync(ChangeUnitRequest request);

        #endregion

    }
}
