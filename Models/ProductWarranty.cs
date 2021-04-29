using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ProductWarranty
    {
        public int ProductId { get; set; }
        public int WarrantyInMonths { get; set; }
        public Product Product { get; set; }
    }
}
