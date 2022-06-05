using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Models
{
    public class Sale
    {
        public long Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public long? SalesPointId { get; set; }
        public long? BuyerId { get; set; }
        public long? TotalAmount { get; set; }


        public virtual Buyer Buyer { get; set; }
        public virtual SalesPoint SalesPoint { get; set; }

        public virtual ICollection<SaleData> SalesData { get; set; }

    }
}
