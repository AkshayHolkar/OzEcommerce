using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.OrderViewModels
{
    public class OrderSuccessViewModel
    {
        public Account Account { get; set; }
        public Address Address { get; set; }
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
