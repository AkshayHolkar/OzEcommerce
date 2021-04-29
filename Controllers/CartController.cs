using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using OzEcommerceV14.Models.ViewModels.CartsViewModel;

namespace OzEcommerceV14.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CartController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cartProducts = _context.Cart.Where(p => p.CustomerId == userId).ToList();

            CartViewModel cart = new CartViewModel();

            cart.Cart = SetCartSets(cartProducts);

            return View(cart);
        }

        public List<CartItemsViewModel> SetCartSets(List<Cart> cartProducts)
        {
            List<CartItemsViewModel> carts = new List<CartItemsViewModel>();
            foreach (var c in cartProducts)
            {
                CartItemsViewModel model = new CartItemsViewModel();

                model.Id = c.Id;
                model.ProductId = c.ProductId;
                model.ProductName = c.ProductName;
                model.Photo = c.Photo;
                model.Color = c.Color;
                model.Size = c.Size;
                model.DiscountPrice = c.DiscountPrice;
                model.ComboPrice = c.ComboPrice;
                model.Quantity = c.Quantity;
                model.MaxLimit = c.MaxLimit;
                model.OriginalPrice = c.OriginalPrice;
                if(c.Color != null)
                {
                    model.Colours = _context.Colour.Where(p => p.ProductId == c.ProductId).ToList();
                }
                if (c.Size != null)
                {
                    var productSizes = _context.ProductSize.Where(p => p.ProductId == c.ProductId).ToList();
                    model.ProductSize = new List<SelectListItem>();
                    foreach (var p in productSizes)
                    {
                        var selectListItem = new SelectListItem()
                        {
                            Text = p.ItemSize,
                        };
                        model.ProductSize.Add(selectListItem);
                    }
                }
                carts.Add(model);
            }
            return carts;
        }

        public IActionResult AddCart(ProductDetailViewModel productDetail)
        {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                if (productDetail.ProductId != 0)
                {
                    var cart = _context.Cart.Where(p => p.CustomerId == userId).ToList();

                    if (cart.Count() > 0)
                    {
                        if (cart.Any(p => p.ProductId == productDetail.ProductId) == true)
                        {
                            var c = _context.Cart.FirstOrDefault(p => p.ProductId == productDetail.ProductId);
                            Cart model = new Cart();
                            model = c;
                            _context.Cart.Remove(model);
                            _context.SaveChanges();
                        }
                        if (cart.Any(p => p.VendorId == productDetail.VendorId) == true)
                        {
                            int q;
                            if (productDetail.Quantity > productDetail.MaxLimit || productDetail.Quantity < 1)
                            {
                                q = productDetail.MaxLimit;
                            }
                            else
                            {
                                q = productDetail.Quantity;
                            }

                            Cart model = new Cart();
                            model.ProductId = productDetail.ProductId;
                            model.ProductName = productDetail.Name;
                            model.Photo = productDetail.FImage;
                            if (productDetail.SelectedColor == "false")
                            {
                                model.Color = productDetail.DefaultColor;
                            }
                            else
                            {
                                model.Color = productDetail.SelectedColor;
                            }
                            model.Size = productDetail.SelectedSize;
                            model.CustomerId = userId;
                            model.VendorId = productDetail.VendorId;
                            model.Quantity = q;
                            model.OriginalPrice = productDetail.Price;
                            model.DiscountPrice = productDetail.DiscountPrice;
                            model.ComboPrice = productDetail.ComboPrice;
                            model.MaxLimit = productDetail.MaxLimit;

                            _context.Cart.Add(model);
                            _context.SaveChanges();
                        }
                        else
                        {      

                        }
                    }
                    else
                    {
                        int q;
                        if (productDetail.Quantity > productDetail.MaxLimit || productDetail.Quantity < 1)
                        {
                            q = productDetail.MaxLimit;
                        }
                        else
                        {
                            q = productDetail.Quantity;
                        }

                        Cart model = new Cart();
                        model.ProductId = productDetail.ProductId;
                        model.ProductName = productDetail.Name;
                        model.Photo = productDetail.FImage;
                        if (productDetail.SelectedColor == "false")
                        {
                            model.Color = productDetail.DefaultColor;
                        }
                        else
                        {
                            model.Color = productDetail.SelectedColor;
                        }
                        model.Size = productDetail.SelectedSize;
                        model.CustomerId = userId;
                        model.VendorId = productDetail.VendorId;
                        model.Quantity = q;
                        model.OriginalPrice = productDetail.Price;
                        model.DiscountPrice = productDetail.DiscountPrice;
                        model.ComboPrice = productDetail.ComboPrice;
                        model.MaxLimit = productDetail.MaxLimit;

                        _context.Cart.Add(model);
                        _context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Product");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public string GetMainImage(int Id)
        {
                var images = _context.Image.Where(c => c.ProductId == Id).ToList();
                string mainImage = null;
                foreach (var image in images)
                {
                    if (image.Main == true)
                    {
                        mainImage = image.Name;
                    }
                }
                return mainImage;
        }

        [Route("update")]
        [HttpPost]
        public async Task<IActionResult> Update(IFormCollection fc)
        {
            int Id = Convert.ToInt32(fc["Id"]);

            int Quantity = Convert.ToInt32(fc["quantity"]);

            int MaxLimit = Convert.ToInt32(fc["MaxLimit"]);

            int q = 0;
            if (Quantity > MaxLimit)
            {
                q = MaxLimit;
            }
            else
            {
                q = Quantity;
            }

            var item = _context.Cart.Find(Id);
                       
            item.Quantity = q;
           
            _context.Update(item);
                await _context.SaveChangesAsync();
      
            return RedirectToAction("Index");
        }

        [Route("addbundle")]
        [HttpPost]
        public IActionResult AddBundle(IFormCollection fc)
        {
            int Id = Convert.ToInt32(fc["Id"]);
 
            int Quantity = 1;

            var products = _context.ComboProduct.Where(p=>p.RecommendationId == Id).ToList();

            foreach (var p in products)
            {
                var product = _context.Products.Find(p.ProductId);

                if (product != null)
                {
                    ProductDetailViewModel productDetail = new ProductDetailViewModel();

                    productDetail.ProductId = product.Id;
                    productDetail.Name = product.Name;
                    productDetail.FImage = GetMainImage(product.Id);
                    productDetail.VendorId = product.VendorId;
                    productDetail.Quantity = Quantity;
                    productDetail.MaxLimit = product.Quantity;
                    if (!product.SizeNotApplicable)
                    {
                        productDetail.SelectedSize = _context.ProductSize.FirstOrDefault(p => p.ProductId == product.Id).ItemSize;
                    }
                    if (!product.ColorNotApplicable)
                    {
                            productDetail.SelectedColor = _context.Colour.FirstOrDefault(p => p.ProductId == product.Id).Color;
                    }
                    productDetail.Price = product.Price;
                    var specialPrices = GetPrice(product.Id, product.Price);
                    productDetail.DiscountPrice = specialPrices[0].Item1;
                    productDetail.ComboPrice = specialPrices[0].Item2;

                    AddCart(productDetail);
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var getCart = _context.Cart.Find(Id);
   
                _context.Cart.Remove(getCart);
                await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
   
       public List<Tuple<double, double>> GetPrice(int ProductId, double Price)
         {
            var discount = _context.Discount.FirstOrDefault(p => p.ProductId == ProductId);

            double comboPrice = Convert.ToDouble(Price) - (Convert.ToDouble(Price) * (Convert.ToDouble(discount.DiscountInCombo) / 100));
            double MultiPrice = Convert.ToDouble(Price) - (Convert.ToDouble(Price) * (Convert.ToDouble(discount.DiscountOnMulti) / 100));

            List<Tuple<double, double>> values = new List<Tuple<double, double>>();

            values.Add(new Tuple<double, double>(MultiPrice, comboPrice));

            return values;
        }
    }
}
