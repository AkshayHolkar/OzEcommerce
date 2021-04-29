using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class OrderPlaceViewModel
    {
        public Account Account { get; set; }
        public Address  Address { get; set; }
        public ShippingDetail ShippingDetail { get; set; }
        public List<Cart> OrderDetail { get; set; }
        public string VendorId { get; set; }
        public double ShippingCharges { get; set; }
        public double Total { get; set; }
        public string Token { get; set; }
    }
}
