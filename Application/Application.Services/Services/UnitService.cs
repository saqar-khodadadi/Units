using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Application.Services.Contracts;
using Application.Services.DTOs.AddFactors;
using Application.Services.DTOs.AddUnits;
using Application.Services.DTOs.ChangeUnits;
using Core.Common.Extension;
using Core.Domain;
using Infrastructure.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Services
{
    public class UnitService : IUnitService, IDisposable, IAsyncDisposable
    {
        private Utf8JsonWriter? _jsonWriter = new(new MemoryStream());
        private readonly UnitDbContext _context;
        public UnitService(UnitDbContext context)
        {
            _context = context;
        }

        #region AddUnits

        public async Task<AddBasicUnitResponse> AddBasicUnitAsync(AddBasicUnitRequest request)
        {
            var response = new AddBasicUnitResponse();
            await _context.Unit!.AddAsync(new Unit()
                {
                    ParentId = null,
                    FactorId = 1,
                    EnTitle = request.EnTitle,
                    Title = request.Title,
                    Symbol = request.Symbol,
                    Measurment = request.Measurment,
                    EnMeasurment = request.EnMeasurment
                });
            return response.ReturnWithIsSuccessful("افزودن واحد پایه با موفقیت انجام شد", true);
        }

        public async Task<AddMultipleUnitResponse> AddMultipleUnitAsync(AddMultipleUnitRequest request)
        {
            var response = new AddMultipleUnitResponse();
            if (_context.Unit == null || _context.Factor == null)
                return response.ReturnWithIsSuccessful("افزودن واحد ضریب دار با مشکل مواجه شد", false);
            var parentUnit = await _context.Unit.FindAsync(request?.ParentId);
            var factorUnit = await _context.Factor.FindAsync(request?.FactorId);

            if (parentUnit == null || parentUnit.ParentId!=null || factorUnit?.KindId != 2)
                return response.ReturnWithIsSuccessful("افزودن واحد ضریب دار با مشکل مواجه شد", false);
            await _context.Unit.AddAsync(new Unit()
            {
                ParentId = request.ParentId,
                FactorId = request.FactorId,
                EnTitle = request.EnTitle,
                Title = request.Title,
                Symbol = request.Symbol,
                Measurment = parentUnit.Measurment,
                EnMeasurment = parentUnit.EnMeasurment
            });
            return response.ReturnWithIsSuccessful("افزودن واحد ضریب دار با موفقیت انجام شد", true);
        }

        public async Task<AddFormulaUnitResponse> AddFormulaUnitAsync(AddFormulaUnitRequest request)
        {
            var response = new AddFormulaUnitResponse();
            if (_context.Unit == null || _context.Factor == null)
                return response.ReturnWithIsSuccessful("افزودن واحد فرمول دار با مشکل مواجه شد", false);
            var parentUnit = await _context.Unit.FindAsync(request?.ParentId);
            var factorUnit = await _context.Factor.FindAsync(request?.FactorId);

            if (parentUnit == null || parentUnit.ParentId!=null || factorUnit?.KindId != 3)
                return response.ReturnWithIsSuccessful("افزودن واحد فرمول دار با مشکل مواجه شد", false);
            await _context.Unit.AddAsync(new Unit()
            {
                ParentId = request?.ParentId,
                FactorId = request!.FactorId,
                EnTitle = request.EnTitle,
                Title = request.Title,
                Symbol = request.Symbol,
                Measurment = parentUnit.Measurment,
                EnMeasurment = parentUnit.EnMeasurment
            });
            return response.ReturnWithIsSuccessful("افزودن واحد فرمول دار با مشکل مواجه شد", true);
        }

        #endregion


        #region AddFactors

        public async Task<AddFormulaFactorResponse> AddFormulaFactorAsync(AddFormulaFactorRequest request)
        {
            var response = new AddFormulaFactorResponse();
            await _context.Factor!.AddAsync(new Factor()
            {
                Title = request.Title,
                ToValue = request.ToValue,
                ToBase = request.ToBase,
                KindId = 3
            })!;
            return response.ReturnWithIsSuccessful("افزودن فرمول با موفقیت انجام شد", true);
        }

        public async Task<AddMultipleFactorResponse> AddMultipleFactorAsync(AddMultipleFactorRequest request)
        {
            var response = new AddMultipleFactorResponse();
            await _context.Factor!.AddAsync(new Factor()
            {
                Title = request.Title,
                ToValue = $"a/{request.Value}",
                ToBase = $"a *{request.Value}",
                KindId = 2
            });
            return response.ReturnWithIsSuccessful("افزودن ضریب با موفقیت انجام شد", true);
        }

        #endregion

        #region ChangeUnits

        public async Task<ChangeUnitResponse> ChangeUnitAsync(ChangeUnitRequest request)
        {
            var response = new ChangeUnitResponse();
            var finalValue = request.Value;
            int sId=-1;
            int dId=-2;
            var SourceUnit = await _context.Unit!.Include(b => b.Factor).FirstOrDefaultAsync(x=>x.Id==request.SourceUnitId);
            var DestinationUnit = await _context.Unit!.Include(b => b.Factor).FirstOrDefaultAsync(x => x.Id == request.DestinationUnitId);

            if (SourceUnit != null && DestinationUnit!=null)
            {
                sId = SourceUnit.ParentId ?? SourceUnit.Id;
                dId = DestinationUnit.ParentId ?? DestinationUnit.Id;
                if (!sId.Equals(dId))
                {
                    return response.ReturnWithIsSuccessful("تبدیل واحد با مشکل مواجه شد", false);
                }

                if (SourceUnit.ParentId!=null)
                {
                    var toBase = SourceUnit.Factor.ToBase;
                    var formula=toBase.Replace("a", $"{request.Value}");
                    finalValue = formula.Eval();
                }

                if (DestinationUnit.ParentId != null);
                {
                    var toValue = DestinationUnit.Factor.ToValue;
                    var formula = toValue.Replace("a", $"{finalValue}");

                    finalValue = formula.Eval();

                }
            }

            response.FinalValue = finalValue;
            return response.ReturnWithIsSuccessful("تبدیل واحد با موفقیت انجام شد", true);
        }

        #endregion

        public void Dispose()
        {
            _context.SaveChanges();
            _context.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.SaveChangesAsync();
            await _context.DisposeAsync();
        }
    }
}


