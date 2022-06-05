using System;
using System.Collections.Generic;

#nullable disable

namespace testAPI.Models
{
    public partial class ProvidedProduct
    {
        public long Id { get; set; }
        public long? SalePointId { get; set; }
        public long? ProductId { get; set; }
        public long? ProductQuantity { get; set; }

        public virtual SalesPoint SalePoint { get; set; }
        public virtual Product Product { get; set; }
    }
}
