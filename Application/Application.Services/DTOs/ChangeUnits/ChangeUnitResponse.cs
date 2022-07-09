using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.DtoHelper;

namespace Application.Services.DTOs.ChangeUnits
{
    public class ChangeUnitResponse:DtoResponse
    {
        public double FinalValue { get; set; }
    }
}
