using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Base;

namespace Core.Domain
{
    public class Kind: BaseEntity
    {
        public virtual ICollection<Factor> Factors { get; set; }
    }
}
