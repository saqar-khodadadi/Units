using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs.AddUnits
{
    public class AddMultipleUnitRequest
    {
        public string Title { get; set; }
        public string EnTitle { get; set; }
        public string Symbol { get; set; }
        public int FactorId { get; set; }
        public int? ParentId { get; set; }
    }
}
