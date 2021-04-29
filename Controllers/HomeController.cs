using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using OzEcommerceV14.Models.ViewModels.ProductViewModel;

namespace OzEcommerceV14.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> userManager;

        public HomeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            //  try
            //  {
            var result = new HomeViewModel();

            var topSelling = _context.TopSelling.OrderByDescending(p => p.Count).Take(8).ToList();

            result.TopSelling = new List<HomeProductViewModel>();

            foreach(var p in topSelling)
            {
                var product = _context.Products.Find(p.ProductId);

                HomeProductViewModel model = new HomeProductViewModel();
                model.Product = product;

                model.AvgRating = GetAvgRatingProduct(product.Id);
                var images = _context.Image.Where(d => d.ProductId == product.Id);
                var mainImage = images.Where(c => c.Main == true);
                var secImage = images.Where(c => c.Main != true).Take(1);

                foreach (var mImage in mainImage)
                {
                    model.MainImage = mImage.Name;
                }

                foreach (var sImage in secImage)
                {
                    model.SecondImage = sImage.Name;
                }
                result.TopSelling.Add(model);
            }
            var products = _context.Products.Where(p=>p.Status == true).OrderByDescending(p=>p.Id).Take(8);

            result.Categories = _context.LifeStyleCategory.ToList();

                foreach(var product in products)
                {
                HomeProductViewModel model = new HomeProductViewModel();
                model.Product = product;

                model.AvgRating = GetAvgRatingProduct(product.Id);
                var images = _context.Image.Where(d => d.ProductId == product.Id);
                var mainImage = images.Where(c => c.Main == true);
                var secImage = images.Where(c => c.Main != true).Take(1);

                foreach (var mImage in mainImage)
                {
                    model.MainImage = mImage.Name;
                }

                foreach (var sImage in secImage)
                {
                    model.SecondImage = sImage.Name;
                }
                result.Products.Add(model);
            }
            //var Combos = _context.ComboRecommendation.Take(8);

            //foreach (var combo in Combos)
            //{
            //    HomeComboViewModel model = new HomeComboViewModel();
            //    model.Combo.Id = combo.Id;
            //    model.Combo.Name = combo.Name;
            //    var images = _context.ComboPhoto.Where(d => d.ComboId == combo.Id);
            //    var mainImage = images.Where(c => c.Main == true);
            //    var secImage = images.Where(c => c.Main != true).Take(1);

            //    foreach (var mImage in mainImage)
            //    {
            //        model.MainImage = mImage.Name;
            //    }

            //    foreach (var sImage in secImage)
            //    {
            //        model.SecondImage = sImage.Name;
            //    }

            //    model.Combo.Price = combo.Price;

            //    result.Combo.Add(model);
            //}
            return View(result);

          //  }
          //  catch(Exception e)
            //{
              //  throw;
            //}
        }

        public IActionResult BecomeVendor()
        {
            return View();
        }

        public double GetAvgRatingHProduct(int productId)
        {
            var reviews = _context.Reviews.Where(p => p.ProductId == productId).ToList();
            double total = 0;

            foreach (var review in reviews)
            {
                total += review.Rating;
            }

            double avg = total / reviews.Count;

            return Math.Round(avg, 0, MidpointRounding.AwayFromZero);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public double GetAvgRatingProduct(int productId)
        {
            var reviews = _context.Reviews.Where(p => p.ProductId == productId).ToList();
            double total = 0;

            foreach (var review in reviews)
            {
                total += review.Rating;
            }

            double avg = total / reviews.Count;

            return Math.Round(avg, 0, MidpointRounding.AwayFromZero);
        }
    }
}
