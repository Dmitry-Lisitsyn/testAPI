using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Models
{
    public class Buyer
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SalesId> SaleIds { get; set; }
    }
}
