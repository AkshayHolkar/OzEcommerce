using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class HomeProductViewModel
    {
        public HomeProductViewModel()
        {
            this.Product = new Product();
        }

        public Product Product { get; set; }
        public string MainImage { get; set; }
        public string SecondImage { get; set; }
        public double AvgRating { get; set; }
    }
}
