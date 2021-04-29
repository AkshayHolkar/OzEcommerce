using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ShippingDetail
    {
        public int ProductId { get; set; }
        public double ShippingCharges { get; set; }
        public bool IsFree { get; set; }
        public Product Product { get; set; }
    }
}
