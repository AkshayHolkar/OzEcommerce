using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;
using OzEcommerceV14.Models.ViewModels;
using OzEcommerceV14.Models.ViewModels.ProductViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ProductListViewModel result = new ProductListViewModel();
            var products = _context.Products.Where(p => p.Status == true).ToList();
            result.Category = new System.Collections.Generic.List<SelectListItem>();

            ViewBag.categories = _context.Category.ToList();

            foreach (var product in products)
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

                result.Product.Add(model);
            }
            return View(result);
        }

        public IActionResult Detail(int Id)
        {
           var product = _context.Products.Find(Id);

            if (product != null)
            {
                var discount = _context.Discount.Where(c => c.ProductId == Id).ToList();

                var comboProduct = _context.ComboProduct.FirstOrDefault(c => c.ProductId == Id);

                ProductDetailViewModel selectedProduct = new ProductDetailViewModel();

                selectedProduct.FImage = GetMainImage(Id);
                selectedProduct.Id = product.Id;
                selectedProduct.ProductName = product.Name;
                selectedProduct.ProductPrice = product.Price;
                selectedProduct.ProductQuantity = product.Quantity;
                selectedProduct.ProductDescription = product.Description;
                selectedProduct.ProductVendorId = product.VendorId;
                selectedProduct.storeName = GetVendorName(product.VendorId);
                selectedProduct.reviews = GetReview(Id);
    
                foreach (var d in discount)
                {
                    selectedProduct.DiscountInCombo = d.DiscountInCombo;
                    selectedProduct.DiscountOnMulti = d.DiscountOnMulti;
                }

                var image = GetImagesName(Id);

                selectedProduct.Images = image;

                if (comboProduct != null)
                {
                    var combo = _context.ComboProduct.Where(p => p.RecommendationId == comboProduct.RecommendationId).ToList();

                    ComboViewModel model = new ComboViewModel();
                    model = GetCombo(combo);
                    selectedProduct.ComboId = model.ComboId;
                    selectedProduct.Combo = model.Combo;
                    selectedProduct.Total = model.Total;
                    selectedProduct.DiscountTotal = model.DiscountTotal;
                }
    
                var productVideo = _context.ProductVideo.Find(Id);

                selectedProduct.Video = productVideo.VideoLink;
                var warranty = _context.ProductWarranty.Find(Id);
                selectedProduct.warranty = warranty.WarrantyInMonths;

                if (!product.SizeNotApplicable && product.ColorNotApplicable)
                {
                    var ProductSize = _context.ProductSize.Where(p => p.ProductId == product.Id).ToList();
                    selectedProduct.ProductSize = new List<SelectListItem>();
                    foreach (var p in ProductSize)
                    {
                        var selectListItem = new SelectListItem()
                        {
                            Text = p.ItemSize,
                        };
                        selectedProduct.ProductSize.Add(selectListItem);
                    }
                    return View(selectedProduct);
                }
                if (!product.ColorNotApplicable && product.SizeNotApplicable)
                {
                    selectedProduct.Colours = _context.Colour.Where(p => p.ProductId == product.Id).ToList();
                    return View(selectedProduct);
                }
                if (!product.SizeNotApplicable && !product.ColorNotApplicable)
                {
                    var ProductSize = _context.ProductSize.Where(p => p.ProductId == product.Id).ToList();
                    selectedProduct.ProductSize = new List<SelectListItem>();
                    foreach (var p in ProductSize)
                    {
                        var selectListItem = new SelectListItem()
                        {
                            Text = p.ItemSize,
                        };
                        selectedProduct.ProductSize.Add(selectListItem);
                    }
                    selectedProduct.Colours = _context.Colour.Where(p => p.ProductId == product.Id).ToList();
                    return View(selectedProduct);
                }

                return View(selectedProduct);
            }
            else
            {
                return RedirectToAction("Index", "Product");
            }
            //  }
            //  catch(Exception e)
            //{
            //  throw;
            //}
        }

        public IActionResult VendorProfile(string Id)
        {
            ViewBag.storeInfo = _context.Vendors.Find(Id);
            var review = _context.Reviews.Where(p => p.VendorId == Id).ToList();
            ViewBag.AvgRating = GetAvgRating(review);
            ViewBag.TotalReview = review.Count();
            var products = _context.Products.Where(p => p.VendorId == Id && p.Status == true).ToList();
            var result = new HomeViewModel();

            foreach (var product in products)
            {
                HomeProductViewModel model = new HomeProductViewModel();
                model.Product.Id = product.Id;
                model.Product.Name = product.Name;
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

                model.Product.Price = product.Price;

                result.Products.Add(model);
            }

            result.Combo = new List<ComboViewModel>();
            result.Combo = GetVendorCombo(Id);
            //var empty = result.Combo.Where(p => p.ComboId == 0);

            //if (empty != null)
            //{
            //    result.Combo.Remove(empty.FirstOrDefault());
            //}            
            return View(result);
        }

        public List<ComboViewModel> GetVendorCombo(string Id)
        {
            var combo = _context.ComboRecommendation.Where(p=>p.VendorId == Id).ToList();

            List<ComboViewModel> comboSet = new List<ComboViewModel>();

            foreach (var c in combo)
            {
                var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == c.Id).ToList();

                comboSet.Add(GetCombo(comboProducts));
            }
        
            return comboSet;
        }

        public IActionResult Recommondation()
        {
            var combo = _context.ComboRecommendation.ToList();

            ViewBag.categories = _context.ComboCategory.ToList();

            ComboSetViewModel comboSet = new ComboSetViewModel();

            foreach (var c in combo)
            {
               
                var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == c.Id).ToList();

                comboSet.comboSet.Add(GetCombo(comboProducts));
            }

            var empty = comboSet.comboSet.Where(p => p.ComboId == 0);

            if (empty != null)
            {
                comboSet.comboSet.Remove(empty.FirstOrDefault());
            }

            return View("Recommondation",comboSet);
        }

        [Route("rFilter/{Id?}/{comboId?}")]
        public IActionResult RFilter(int Id, int comboId)
         {
            ViewBag.categories = _context.ComboCategory.ToList();
            
            List<ComboRecommendation> combo = new List<ComboRecommendation>();
           
            if (comboId == 0 || Id == 0)
            {
                if (comboId == 0)
                {
                    combo = _context.ComboRecommendation.Where(p => p.LifeStyleCategoryId == Id).ToList();
                }
                if(Id== 0)
                {
                    combo = _context.ComboRecommendation.Where(p => p.ComboCategoryId == comboId).ToList();

                }
            }
            else
            {
                combo = _context.ComboRecommendation.Where(p => p.LifeStyleCategoryId == Id && p.ComboCategoryId == comboId).ToList();
            }

            ComboSetViewModel comboSet = new ComboSetViewModel();

            comboSet.LifeStyleId = Id;
            foreach (var c in combo)
            {
                var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == c.Id).ToList();

                comboSet.comboSet.Add(GetCombo(comboProducts));
            }
            return View("RFilter", comboSet);
        }

        [Route("cFilter/{Id?}/{comboId?}")]
        public IActionResult CFilter(int Id, int comboId)
        {
            List<ComboRecommendation> combo = new List<ComboRecommendation>();
            ViewBag.categories = _context.LifeStyleCategory.ToList();

            if (comboId == 0 || Id == 0)
            {
                if (comboId == 0)
                {
                    combo = _context.ComboRecommendation.Where(p => p.LifeStyleCategoryId == Id).ToList();
                }
                if (Id == 0)
                {
                    combo = _context.ComboRecommendation.Where(p => p.ComboCategoryId == comboId).ToList();
                }
            }
            else
            {
                combo = _context.ComboRecommendation.Where(p => p.LifeStyleCategoryId == Id && p.ComboCategoryId == comboId).ToList();
            }
            ComboSetViewModel comboSet = new ComboSetViewModel();

            comboSet.LifeStyleId = comboId;
            foreach (var c in combo)
            {
                var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == c.Id).ToList();

                comboSet.comboSet.Add(GetCombo(comboProducts));
            }
            return View("CFilter", comboSet);
        }


        [Route("search")]
        [HttpGet]
        public IActionResult Search()
        {
            try
            {
                string keyword = Request.Query["keyword"];
                
                var result = new ProductListViewModel();
                var listProducts = _context.Products.Where(p => p.Name.Contains(keyword) && p.Status).ToList();
                result.Category = new System.Collections.Generic.List<SelectListItem>();

                ViewBag.categories = _context.Category.ToList();

                foreach (var product in listProducts)
                {
                    HomeProductViewModel model = new HomeProductViewModel();
                    model.Product.Id = product.Id;
                    model.Product.Name = product.Name;
                    model.AvgRating = GetAvgRatingProduct(product.Id);
                    model.Product.CategoryId = product.CategoryId;
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

                    model.Product.Price = product.Price;

                    result.Product.Add(model);
                }
                return View("Search", result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public IActionResult ByCategory(int Id)
        {
            try
            {
                var result = new ProductListViewModel();
                var listProducts = _context.Products.Where(p => p.CategoryId == Id && p.Status).ToList();
                result.Category = new System.Collections.Generic.List<SelectListItem>();

                ViewBag.categories = _context.Category.ToList();

                foreach (var product in listProducts)
                {
                    HomeProductViewModel model = new HomeProductViewModel();
                    model.Product.Id = product.Id;
                    model.Product.Name = product.Name;
                    model.Product.CategoryId = product.CategoryId;
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

                    model.Product.Price = product.Price;

                    result.Product.Add(model);
                }
                return View("ByCategory", result);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<ReviewViewModel> GetReview(int Id)
        {
            List<ReviewViewModel> reviewView = new List<ReviewViewModel>();

            var reviews = _context.Reviews.Where(p => p.ProductId == Id).ToList();

            foreach(var review in reviews)
            {
                ReviewViewModel model = new ReviewViewModel();
                model.Review = review;
                model.CustomerName = GetCustomerName(review.CustomerId);

                reviewView.Add(model);
            }

            return reviewView;
        }

        public string GetCustomerName(string Id)
        {
            var customer = _context.Account.Find(Id);

            return customer.FullName;
        }

        public ComboViewModel GetCombo(List<ComboProduct> c)
        {
            ComboViewModel combo = new ComboViewModel();
            foreach (var comboProduct in c)
            {
                var product = _context.Products.Find(comboProduct.ProductId);
                
                ComboProductViewModel model = new ComboProductViewModel();
                model.Name = product.Name;
                model.Price = product.Price;
                model.ProductId = product.Id;

                model.Image = GetMainImage(product.Id);

                combo.Combo.Add(model);
                combo.ComboId = comboProduct.RecommendationId;
                combo.Total += model.Price;
                combo.DiscountTotal += GetDiscountTotal(product.Id, model.Price);
            }
            return combo;
        }

        public List<string> GetImagesName(int Id)
        {
                var images = _context.Image.Where(c => c.ProductId == Id).ToList();
                var imageList = new List<string>();
                foreach (var image in images)
                {
                    imageList.Add(image.Name);
                }

                return imageList;
        }

        public string GetMainImage(int Id)
        {
            var images = _context.Image.Where(c => c.ProductId == Id).ToList();
            string mainImage = null;
            if (images == null)
            {
                var a = 0;
            }
            foreach (var image in images)
            {
                if (image.Main == true) 
                {
                    mainImage = image.Name;
                    break;
                }
            }

            return mainImage;
        }

        public double GetDiscountTotal(int Id, double price)
        {
            var discount = _context.Discount.Where(p => p.ProductId == Id).ToList();
            double newPrice = 0;
            foreach(var d in discount)
            {
                newPrice = price - price * d.DiscountInCombo / 100;
            }
            return newPrice;
        }

        public string GetVendorName(string Id)
        {
            var vendor = _context.Vendors.Find(Id);
            string name = vendor.StoreName;

            return name;
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

        public double GetAvgRating(List<Review> reviews)
        {
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
    }
}
