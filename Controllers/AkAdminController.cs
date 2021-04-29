using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OzEcommerceV14.Models.ViewModels.AdminViewModels;
using Microsoft.AspNetCore.Authorization;

namespace OzEcommerceV14.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AkAdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IHostingEnvironment hostingEnvironment;

        public AkAdminController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.userManager = userManager;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()   
        {
            var customers = userManager.GetUsersInRoleAsync("Customer").Result;
            ViewBag.TotalCustomer = customers.Count();
            var vendors = userManager.GetUsersInRoleAsync("Vendor").Result;
            ViewBag.TotalVendor = vendors.Count();
            ViewBag.TotalSell = GetTotalSell(false, "null");

            return View();
        }

        public IActionResult VendorList()
        {
            VendorListViewModel list = new VendorListViewModel();

            list.List = new List<VendorDetailViewModel>();

            var vendors = userManager.GetUsersInRoleAsync("Vendor").Result;

            foreach(var vendor in vendors)
            {
                VendorDetailViewModel model = new VendorDetailViewModel();

                model = GetVendorDetail(vendor.Id);
                //model.CreatedDate = vendor.CreateDate.DateTime;

               list.List.Add(model);
            }
            return View(list);
        }

        public VendorDetailViewModel GetVendorDetail(string Id)
        {
            var storeDetail = _context.Vendors.Find(Id);
            var totalProducts = _context.Products.Where(p => p.VendorId == Id).Count();
            VendorDetailViewModel model = new VendorDetailViewModel();

            model.VendorId = Id;
            if (storeDetail != null)
            {
                model.StoreName = storeDetail.StoreName;
            }
            else
            {
                model.StoreName = "Store not set";
            }
            model.TotalProducts = totalProducts;
            model.Revenue = GetTotalSell(true, Id); 

            return model;
        }

        public double GetTotalSell(bool forVendor, string vendorId)
        {
            double total = 0;
            if (!forVendor)
            {
                var sell = _context.OrdersDetail.ToList();

                foreach (var s in sell)
                {
                    total += s.TotalPrice;
                }
            }
            else
            {
                var Orders = _context.Order.Where(p=>p.VendorId == vendorId).ToList();

                foreach(var order in Orders)
                {
                    var orderdetails = _context.OrdersDetail.Where(p => p.OrderId == order.Id).ToList();

                    foreach (var s in orderdetails)
                    {
                        total += s.TotalPrice;
                    }
                }
            }

            return total;
        }
    }
}
