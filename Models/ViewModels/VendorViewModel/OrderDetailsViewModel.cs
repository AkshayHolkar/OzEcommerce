using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.VendorViewModel
{
    public class OrderDetailsViewModel
    {
        public List<OrderDetail> OrderDetail { get; set; }
        public Address ShippingDetail { get; set; }
        public Account CustomerDetail { get; set; }
        public ShippingTracker ShippingTracker { get; set; }
        public string TrackingNumber { get; set; }
        public int OrderId { get; set; }
    }
}
