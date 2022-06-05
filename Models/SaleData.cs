using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testAPI.Models
{
    public class SaleData
    {
        public long Id { get; set; }
        public long? ProductId { get; set; }
        public long? ProductQuantity { get; set; }
        public long? ProductIdAmount { get; set; }
        public long? SaleId { get; set; }


        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }

    }
}
