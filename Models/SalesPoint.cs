using System;
using System.Collections.Generic;

#nullable disable

namespace testAPI.Models
{
    public partial class SalesPoint
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProvidedProduct> ProvidedProducts { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
