using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.DTOs.AddFactors
{
    public class AddFormulaFactorRequest
    {
        public string Title { get; set; }
        [RegularExpression(@"[.+*-/ ()a[0-9]*",
        ErrorMessage = "لطفا فرمول را صحیح وارد کنید")]
        public string ToValue { get; set; }
        [RegularExpression(@"[.+*-/ ()a[0-9]*",
            ErrorMessage = "لطفا فرمول را صحیح وارد کنید")]
        public string ToBase { get; set; }
    }
}
