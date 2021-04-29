using OzEcommerceV14.Models.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            this.Product = new List<ProductListItemViewModel>();
            this.Products = new List<HomeProductViewModel>();
            this.Combo = new List<ComboViewModel>();
        }
        public List<ProductListItemViewModel> Product { get; set; }
        public List<HomeProductViewModel> Products { get; set; }
        public List<HomeProductViewModel> TopSelling { get; set; }
        public List<LifeStyleCategory> Categories { get; set; }
        public ComboSetViewModel VendorCombo { get; set; }
        public List<ComboViewModel> Combo { get; set; }
    }
}
