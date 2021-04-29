using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.CartsViewModel
{
    public class CartItemsViewModel
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double DiscountPrice { get; set; }
        public double ComboPrice { get; set; }
        public int Quantity { get; set; }
        public int MaxLimit { get; set; }
        public string VendorId { get; set; }
        public double OriginalPrice { get; set; }
        public List<SelectListItem> ProductSize { get; set; }
        public List<Colour> Colours { get; set; }
        public string UpdatedColor { get; set; }
        public string UpdatedSize { get; set; }
    }
}
