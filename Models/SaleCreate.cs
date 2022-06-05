using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Models
{
    public class SaleCreate
    {
        public long SalesPointId { get; set; }
        public long? BuyerId { get; set; }
        public long ProductId { get; set; }
        public long ProductQuantity { get; set; }
    }
}
