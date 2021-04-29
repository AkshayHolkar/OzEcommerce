using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.CustomerViewModel
{
    public class OrderDetailViewModel
    {
        public List<OrderDetail> OrderDetail { get; set; }
        public string TrackingNumber { get; set; }
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
    }
}
