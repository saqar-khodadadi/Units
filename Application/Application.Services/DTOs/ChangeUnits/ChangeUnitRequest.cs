using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs.ChangeUnits
{
    public class ChangeUnitRequest
    {
        public double Value { get; set; }
        public int SourceUnitId { get; set; }
        public int DestinationUnitId { get; set; }

    }
}
