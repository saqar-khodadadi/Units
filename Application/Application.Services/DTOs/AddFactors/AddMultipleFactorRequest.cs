using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs.AddFactors
{
    public class AddMultipleFactorRequest
    {
        public string Title { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "لطفا ضریب را به صورت عدد وارد کنید")]
        public string Value { get; set; }
    }
}
