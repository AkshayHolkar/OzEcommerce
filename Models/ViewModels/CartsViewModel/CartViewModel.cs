using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.CartsViewModel
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            this.Cart = new List<CartItemsViewModel>();
        }
        public List<CartItemsViewModel> Cart { get; set; }
        public double Total { get; set; }
    }
}
