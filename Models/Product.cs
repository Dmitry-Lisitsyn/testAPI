using System;
using System.Collections.Generic;

#nullable disable

namespace testAPI.Models
{
    public partial class Product
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public long? Price { get; set; }
    }
}
