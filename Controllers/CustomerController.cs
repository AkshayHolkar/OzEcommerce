using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using OzEcommerceV14.Models.ViewModels.CustomerViewModel;
using OzEcommerceV14.Models.ViewModels.OrderViewModels;
using OzEcommerceV14.Models.ViewModels.VendorViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public CustomerController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.Messages = _context.Message.Where(p => p.CustomerId == userId && p.SenderCustomer == false && p.Status == false).Count();

            OrderSuccessViewModel userDetail = new OrderSuccessViewModel();

            userDetail.Account = _context.Account.Find(userId);

            var addresses = _context.Address.Where(p => p.UserId == userId).ToList();

            foreach(var address in addresses)
            {
                userDetail.Address = address;
            }
            return View(userDetail);
        }

        public IActionResult Order()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<OrderViewModel> orderView = new List<OrderViewModel>();

            var orders = _context.Order.Where(p => p.CustomerId == userId).OrderByDescending(p=>p.Id);  
            
            foreach(var order in orders)
            {
                OrderViewModel model = new OrderViewModel();

                model.OrderId = order.Id;
                model.Date = order.DateCreation;
                model.Name = GetVendor(order.VendorId);
                model.Status = GetStatus(order.OrderStatusId);

                orderView.Add(model);
            }
            return View(orderView);
        }

        public IActionResult OrderDetail(int Id)
        {
            var details = _context.OrdersDetail.Where(p => p.OrderId == Id).ToList();

            OrderDetailViewModel orderDetail = new OrderDetailViewModel();

            orderDetail.OrderId = Id;

            List<OrderDetail> list = new List<OrderDetail>();

            foreach(var detail in details)
            {
                list.Add(detail);
            }

            var track = _context.ShippingTrackers.Find(Id);
            orderDetail.OrderDetail = list;
            if (track == null)
            {
                orderDetail.TrackingNumber = null;
                orderDetail.CompanyName = null;
            }
            else
            {
                orderDetail.TrackingNumber = track.TrackingNumber;
                orderDetail.CompanyName = track.CompanyName;
            }
            return View(orderDetail);
        }

        public IActionResult ProductsReview()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var orders = _context.Order.Where(p => p.CustomerId == userId).ToList();

            List<int> productIds = new List<int>();

            foreach(var order in orders)
            {
                var orderDetail = _context.OrdersDetail.Where(p => p.OrderId == order.Id).ToList();

                foreach(var product in orderDetail)
                {
                    if (productIds.IndexOf(product.ProductId) == -1)
                    {
                        productIds.Add(product.ProductId);
                    }
                }
            }
            var reviews = _context.Reviews.Where(p => p.CustomerId == userId).ToList();

            foreach(var review in reviews)
            {
                productIds.Remove(review.ProductId);
            }

            List<Cart> products = new List<Cart>();
            foreach(var Id in productIds)
            {
                var product = _context.Products.Find(Id);
                if (product != null)
                {
                    Cart model = new Cart();
                    model.ProductId = product.Id;
                    model.ProductName = product.Name;
                    model.Photo = GetMainImage(Id);
                    products.Add(model);
                }
            }                   
            return View(products);
        }

        //[Route("addReview")]
        //[HttpGet]
        public IActionResult AddReview(int Id)
        {
            var product = _context.Products.Find(Id);
            return View("AddReview",product);
        }

        [Route("Review")]
        [HttpPost]
        public async Task<IActionResult> Review(IFormCollection fc)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            int productId = Convert.ToInt32(fc["productId"]);
            int rate = Convert.ToInt32(fc["rate"]);
            string vendorId = fc["vendorId"];
            string title = fc["rTitle"];
            string review = fc["review"];

            Review model = new Review();
            model.CustomerId = userId;
            model.DatePost = DateTime.Now.Date;
            model.ProductId = productId;
            model.Title = title;
            model.Detail = review;
            model.VendorId = vendorId;
            model.Rating = rate;

            _context.Reviews.Add(model);
            await _context.SaveChangesAsync();

            return RedirectToAction("ProductsReview");
        }

        [Route("sendMessage")]
        [HttpGet]
        public IActionResult SendMessage(int Id)
        {
            try
            {
                Message message = new Message();
                message.OrderId = Id;
                return View(message);
            }catch(Exception e)
            {
                throw;
            }
        }

        [Route("sendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = _context.Order.Find(message.OrderId);

            if (ModelState.IsValid)
            {
                Message model = new Message();
                model.OrderId = order.Id;
                model.Title = message.Title;
                model.Body = message.Body;
                model.CustomerId = userId;
                model.VendorId = order.VendorId;
                model.DateCreation = DateTime.Now.Date;
                model.SenderCustomer = true;
                model.Status = false;

                _context.Message.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("SendedSuccessfully");
            }
            else
            {
                Message m = new Message();
                m.OrderId = order.Id;
                return View(m);
            }
        }

        public IActionResult SendedSuccessfully()
        {
            return View();
        }

        public IActionResult Messages()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = _context.Message.Where(p => p.CustomerId == userId && p.SenderCustomer == false).OrderByDescending(o => o.DateCreation).ToList();

            MessageListViewModel model = new MessageListViewModel();

            model.Messages = messages;

            return View(model);
        }

        public IActionResult CMessageDetail(int Id)
        {
            var message = _context.Message.Find(Id);

            message.Status = true;
            _context.Message.Update(message);
            _context.SaveChangesAsync();

            return View(message);
        }

        [Route("addAccount")]
        [HttpGet]
        public IActionResult AddAccount()
        {
           return View();
        }

        [Route("addAccount")]
        [HttpPost]
        public async Task<IActionResult> AddAccount(Account Account)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Account model = new Account();
                model.UserId = userId;
                model.FullName = Account.FullName;
                model.Email = Account.Email;
                model.Phone = Account.Phone;
                model.Status = true;
               
                _context.Account.Add(model);
                await _context.SaveChangesAsync();
    
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("addAddress")]
        [HttpGet]
        public IActionResult AddAddress()
        {
            return View();
        }

        [Route("addAddress")]
        [HttpPost]
        public async Task<IActionResult> AddAddress(Address Address)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Address model = new Address();
                model.UserId = userId;
                model.Property = Address.Property;
                model.StreetName = Address.StreetName;
                model.City = Address.City;
                model.State = Address.State;
                model.Postcode = Address.Postcode;
                model.Country = "Australia";

                _context.Address.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("editAccount")]
        [HttpGet]
        public IActionResult EditAccount()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Account = _context.Account.Find(userId);

            return View(Account);
        }

        [Route("editAccount")]
        [HttpPost]
        public async Task<IActionResult> EditAccount(Account Account)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                var a = _context.Account.Find(userId);

                Account model = new Account();
                model = a;
                model.FullName = Account.FullName;
                model.Email = Account.Email;
                model.Phone = Account.Phone;

                _context.Account.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [Route("editAddress")]
        [HttpGet]
        public IActionResult EditAddress()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var address = _context.Address.FirstOrDefault(p=>p.UserId==userId);

            return View(address);
        }

        [Route("editAddress")]
        [HttpPost]
        public async Task<IActionResult> EditAddress(Address Address)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                var a = _context.Address.FirstOrDefault(p => p.UserId == userId);

                Address model = new Address();
                model = a;
                model.Property = Address.Property;
                model.StreetName = Address.StreetName;
                model.City = Address.City;
                model.State = Address.State;
                model.Postcode = Address.Postcode;

                _context.Address.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View();
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

        public string GetStatus(int Id)
        {
            var status = _context.OrderStatus.Find(Id);

            return status.Name;
        }

        public string GetVendor(string Id)
        {
            var storeInfo = _context.Vendors.Where(p=>p.VendorId==Id);

            var storeName = "";

            foreach(var store in storeInfo)
            {
                storeName = store.StoreName;
            }
            return storeName;
        }
    }
}
