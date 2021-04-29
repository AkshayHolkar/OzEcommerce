using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ShippingTracker
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string TrackingNumber { get; set; }
        public virtual Order Order { get; set; }
    }
}
