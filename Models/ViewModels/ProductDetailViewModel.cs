using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzEcommerceV14.Models.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel()
        {
            this.Combo = new List<ComboProductViewModel>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string ProductDescription { get; set; }
        public string ProductVendorId { get; set; }
        public bool ProductSizeNotApplicable { get; set; }
        public bool ProductColorNotApplicable { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string  FImage { get; set; }
        public List<string> Images { get; set; }
        public string Video { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public double DiscountPrice { get; set; }
        public double ComboPrice { get; set; }
        public int MaxLimit { get; set; }
        public string storeName { get; set; }
        public List<ReviewViewModel> reviews { get; set; }
        public int warranty { get; set; }
        public int DiscountInCombo { get; set; }
        public int DiscountOnMulti { get; set; }
        public int ComboId;
        public List<ComboProductViewModel> Combo { get; set; }
        public double Total { get; set; }
        public double DiscountTotal { get; set; }
        public List<SelectListItem> ProductSize { get; set; }
        public string SelectedSize { get; set; }
        public string SelectedColor { get; set; }
        public string DefaultColor { get; set; }
        public List<Colour> Colours { get; set; }
    }
}
