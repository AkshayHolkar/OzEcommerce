using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.ProductViewModel
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            this.Product = new List<HomeProductViewModel>();
            this.Combo = new List<ComboViewModel>();
        }
        public List<SelectListItem> Category { get; set; }
        public List<HomeProductViewModel> Product { get; set; }
        public List<ComboViewModel> Combo { get; set; }
    }
}
