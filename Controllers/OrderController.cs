using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using OzEcommerceV14.Models.ViewModels.OrderViewModels;
//using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public OrderController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Index(string Id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            OrderPlaceViewModel orderPlace = new OrderPlaceViewModel();

            orderPlace.Account = _context.Account.Find(userId);

            var addresses = _context.Address.Where(p => p.UserId == userId);

            foreach (var address in addresses)
            {
                orderPlace.Address = address;
            }

            var detail = _context.Cart.Where(p => p.CustomerId == userId).ToList();
            orderPlace.OrderDetail = detail;
             orderPlace.VendorId = Id;

            return View(orderPlace);
        }

        [HttpGet]
        [Route("address")]
        public IActionResult Address()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var addresses = _context.Address.Where(p => p.UserId == userId);
                Address currentAddress = new Address();
                foreach (var address in addresses)
                {
                    currentAddress = address;
                }

                return View("Address", currentAddress);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("address")]
        public async Task<IActionResult> Address(Address address)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cAddress = _context.Address.SingleOrDefault(p => p.UserId == userId);

            if (ModelState.IsValid)
            {
                if (cAddress == null)
                {
                    Address a = new Address();
                    a.UserId = userId;
                    a.Property = address.Property;
                    a.StreetName = address.StreetName;
                    a.State = address.State;
                    a.City = address.City;
                    a.Country = address.Country;
                    a.Postcode = address.Postcode;
                    _context.Address.Add(a);
                }
                else
                {
                    cAddress.Property = address.Property;
                    cAddress.StreetName = address.StreetName;
                    cAddress.State = address.State;
                    cAddress.Postcode = address.Postcode;
                    cAddress.Country = address.Country;
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("PersonalInfo");
            }
            else
            {
                var addresses = _context.Address.Where(p => p.UserId == userId);
                Address currentAddress = new Address();
                foreach (var a in addresses)
                {
                    currentAddress = a;
                }

                return View("Address", currentAddress);
            }
        }

        [HttpGet]
        [Route("personalinfo")]
        public IActionResult PersonalInfo()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var account = _context.Account.Find(userId);
                Account currentDetail = new Account();

                currentDetail = account;

                return View("PersonalInfo", currentDetail);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("personalinfo")]
        public async Task<IActionResult> PersonalInfo(Account account)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentAccount = _context.Account.SingleOrDefault(p => p.UserId == userId);

            if (ModelState.IsValid)
            {
                if (currentAccount == null)
                {
                    Account a = new Account();
                    a = account;
                    a.Status = true;
                    a.UserId = userId;
                    _context.Account.Add(a);
                }
                else
                {
                    currentAccount.FullName = account.FullName;
                    currentAccount.Email = account.Email;
                    currentAccount.Phone = account.Phone;
                }
                await _context.SaveChangesAsync();

                return RedirectToAction("Payment");
            }
            else
            {
                var oldaccount = _context.Account.Find(userId);
                Account currentDetail = new Account();

                currentDetail = oldaccount;

                return View("PersonalInfo", currentDetail);
            }
        }

        [HttpGet]
        [Route("payment")]
        public IActionResult Payment()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                var orderSummery = _context.Cart.Where(p => p.CustomerId == userId).ToList();
                
                OrderPlaceViewModel orderPlace = new OrderPlaceViewModel();

                orderPlace.OrderDetail = orderSummery;
                orderPlace.ShippingDetail = GetShippingCharges(orderSummery);

                return View("Payment", orderPlace);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("payment")]
        public async Task<IActionResult> Payment(OrderPlaceViewModel orderPlace)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var carts = _context.Cart.Where(p => p.CustomerId == userId).ToList();
            string vendorId = "";

            foreach (var cart in carts)
            {
                vendorId = cart.VendorId;
            }

            Order order = new Order();

            order.CustomerId = userId;
            order.DateCreation = DateTime.Now.Date;
            order.VendorId = vendorId;
            order.OrderStatusId = 1;
            order.PaymentId = 1;

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            var orderId = order.Id;

            foreach (var cart in carts)
            {
                TopSelling topmodel = new TopSelling();

                var topseller = _context.TopSelling.FirstOrDefault(p => p.ProductId == cart.ProductId);

                if(topseller != null)
                {
                    topmodel = topseller;
                    topmodel.Count = topseller.Count + 1;

                    _context.TopSelling.Update(topseller);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    topmodel = new TopSelling { ProductId = cart.ProductId, Count = 1 };

                    _context.TopSelling.Add(topmodel);
                    await _context.SaveChangesAsync();
                }
                OrderDetail model = new OrderDetail();

                model.OrderId = orderId;
                model.ProductId = cart.ProductId;
                model.ProductName = cart.ProductName;
                model.Color = cart.Color;
                model.Size = cart.Size;
                model.OriginalTotal = cart.OriginalPrice * cart.Quantity;
                model.ShippingCharge = orderPlace.ShippingCharges;
                if (carts.Count() > 1 || cart.Quantity > 1)
                {
                    if (carts.Count > 1)
                    {
                        model.TotalPrice = cart.ComboPrice * cart.Quantity;
                    }
                    else
                    {
                        model.TotalPrice = cart.DiscountPrice * cart.Quantity;
                    }
                }
                else {
                    model.TotalPrice = cart.OriginalPrice;
                }
                model.Quantity = cart.Quantity;

                _context.OrdersDetail.Add(model);
                await _context.SaveChangesAsync();
            }

            foreach (var cart in carts)
            {
                int Id = cart.ProductId;
                var product = _context.Products.Find(Id);

                int q = product.Quantity - cart.Quantity;

                Product model = new Product();

                model = product;
                model.Quantity = q;

                _context.Products.Update(model);
                await _context.SaveChangesAsync();
            }

            RemoveCarts(carts);

            return RedirectToAction("Success", "Order", new { @Id = orderId });
        }

        public IActionResult Success(int Id)
        {    
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            OrderSuccessViewModel detail = new OrderSuccessViewModel();

            detail.Order = _context.Order.Find(Id);
           
            detail.OrderDetail = _context.OrdersDetail.Where(p => p.OrderId == Id).ToList();
            detail.Account = _context.Account.Find(userId);

             detail.Address = _context.Address.FirstOrDefault(p => p.UserId == userId);

            return View(detail);
        }

        public void RemoveCarts(List<Cart> carts)
        {
            foreach (var cart in carts)
            {
                _context.Cart.Remove(cart);
                _context.SaveChangesAsync();
            }
        }

        public ShippingDetail GetShippingCharges(List<Cart> carts)
        {
            ShippingDetail detail = new ShippingDetail();

            double maxCharge = 0;
            List<int> productIds = new List<int>();

            foreach(var cart in carts)
            {
                productIds.Add(cart.ProductId);
            }
       
            foreach(var productId in productIds)
            {
                var shippingdetail = _context.ShippingDetail.Find(productId);
               
                if(maxCharge< shippingdetail.ShippingCharges)
                {
                    maxCharge = shippingdetail.ShippingCharges;
                }
                
            }

            detail.ShippingCharges = maxCharge;
            if (maxCharge == 0)
            {
                detail.IsFree = true;
            }
            else 
            {
                detail.IsFree = false;
            }
            return detail;
        }

        //public IActionResult Charge(string stripeEmail, string stripeToken)
        //{
        //    var customers = new CustomerService();
        //    var charges = new ChargeService();
        //    var customer = customers.Create(new CustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        Source = stripeToken
        //    });

        //    var charge = charges.Create(new ChargeCreateOptions
        //    {

        //        Amount = 500,
        //        Description = "Test Payment",
        //        Currency = "aud",
        //        Customer = customer.Id

        //    }) ;

        //    if(charge.Status == "succeeded")
        //    {
        //        string BalanceTransactionId = charge.BalanceTransactionId;
        //        return View();
        //    }
        //    else
        //    {

        //    }       
        //    return View();
        //}
    }
}
