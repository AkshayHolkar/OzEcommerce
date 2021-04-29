using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.CustomerViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
