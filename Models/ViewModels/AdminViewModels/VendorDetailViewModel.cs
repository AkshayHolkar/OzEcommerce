using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.AdminViewModels
{
    public class VendorDetailViewModel
    {
        public string VendorId { get; set; }
        public string StoreName { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TotalProducts { get; set; }
        public double Revenue { get; set; }
    }
}
