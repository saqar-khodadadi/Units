using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Factor: BaseEntity
    {
        public string ToValue { get; set; }
        public string ToBase { get; set; }
        public int KindId { get; set; }
        public virtual Kind Kind { get; set; }
        public virtual ICollection<Unit> Units { get; set; }
    }
}
