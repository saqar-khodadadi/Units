using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Unit:BaseEntity
    {
        public string EnTitle { get; set; }
        public string Symbol { get; set; }
        public string Measurment { get; set; }
        public string EnMeasurment { get; set; }

        public int FactorId { get; set; }
        public virtual Factor Factor { get; set; }
        public int? ParentId { get; set; }
        public virtual Unit ParentUnit { get; set; }
        public virtual ICollection<Unit> ChildUnits { get; set; }
    }
}
