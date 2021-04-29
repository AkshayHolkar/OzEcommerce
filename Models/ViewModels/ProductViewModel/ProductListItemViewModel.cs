using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.ProductViewModel
{
    public class ProductListItemViewModel
    {
        public Product Product { get; set; }
        public List<Image> Images { get; set; }
        public string MainImage { get; set; }
        public string SecondImage { get; set; }
        public double AvgRating { get; set; }
    }
}
