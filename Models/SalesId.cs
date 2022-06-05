using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Models
{
    public class SalesId
    {
        public long Id { get; set; }
        public long? BuyerId { get; set; }
        public long? SaleId { get; set; }

        public virtual Buyer Buyer { get; set; }
        public virtual Sale Sale { get; set; }
    }
}
