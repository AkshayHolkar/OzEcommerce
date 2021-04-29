using ImageMagick;
using ImageMagick.ImageOptimizers;
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
using OzEcommerceV14.Models.ViewModels.ProductViewModel;
using OzEcommerceV14.Models.ViewModels.VendorViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.Controllers
{
    [Authorize(Roles = "Vendor")]
    public class VendorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment hostingEnvironment;

        public VendorController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var total = _context.Products.Where(p => p.VendorId == userId && p.Status).Count();

            var messages = _context.Message.Where(p => p.VendorId == userId && p.SenderCustomer == true && p.Status == false).Count();

            ViewBag.TotalEarning = GetTotalEarning(userId);
            ViewBag.TotalProduct = total;
            ViewBag.TotalUnReadMessage = messages;

            var storeInfo = _context.Vendors.Find(userId);
            return View(storeInfo);
        }

        public IActionResult ProductView()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var products = _context.Products.Where(d => d.VendorId == userId && d.Status);
            HomeViewModel VendorProducts = new HomeViewModel();

            foreach (var product in products)
            {
                HomeProductViewModel model = new HomeProductViewModel();
                model.Product = product;
                model.MainImage = GetMainImage(product.Id);
                model.AvgRating = GetAvgRatingProduct(product.Id);

                VendorProducts.Products.Add(model);
            }

            var combo = _context.ComboRecommendation.Where(d=>d.VendorId== userId).ToList();

            foreach (var c in combo)
            {
                var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == c.Id).ToList();

                VendorProducts.Combo.Add(GetCombo(comboProducts));                               
            }

            return View(VendorProducts);
        }

        [HttpGet]
        [Route("addProduct")]
        public IActionResult AddProduct()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (_context.Vendors.Any(p => p.VendorId == userId))
                {
                    var addProduct = new AddProductViewModel();
                    addProduct.Categories = new List<SelectListItem>();
                    addProduct.ComboCategories = new List<SelectListItem>();
                    addProduct.ProductSize = new List<Size>();
                   
                    addProduct.ProductSize = _context.Size.ToList();
                    var categories = _context.Category.ToList();

                    foreach (var category in categories)
                    {
                        var group = new SelectListGroup { Name = category.Name };
                        foreach (var subCategory in category.InverseParents)
                        {
                            if (subCategory.ParentId != null)
                            {
                                var selectListItem = new SelectListItem()
                                {
                                    Text = subCategory.Name,
                                    Value = subCategory.Id.ToString(),
                                    Group = group
                                };
                                addProduct.Categories.Add(selectListItem);
                            }
                        }
                    }

                    var combocategories = _context.LifeStyleCategory.ToList();

                    foreach (var category in combocategories)
                    {
                        var selectListItem = new SelectListItem()
                        {
                            Text = category.Name,
                            Value = category.Id.ToString(),
                        };
                        addProduct.ComboCategories.Add(selectListItem);

                    }
                    return View("AddProduct", addProduct);
                }
                else
                {
                    return View("AddStore");
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> AddProduct(AddProductViewModel productViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                productViewModel.product.VendorId = userId;
                productViewModel.product.Views = 0;
                productViewModel.product.Status = true;

                _context.Products.Add(productViewModel.product);
                await _context.SaveChangesAsync();

                var productId = productViewModel.product.Id;

                if (!productViewModel.product.SizeNotApplicable)
                {
                    foreach(var s in productViewModel.size)
                    {
                        ProductSize model = new ProductSize();
                        model.ProductId = productId;
                        model.ItemSize = s;

                        _context.ProductSize.Add(model);
                        await _context.SaveChangesAsync();
                    }
                }

                if (!productViewModel.product.ColorNotApplicable)
                {
                    if (productViewModel.AddColor1)
                    {
                        Colour model = new Colour();
                        model.ProductId = productId;
                        model.Color = "#"+productViewModel.Color1;

                        _context.Colour.Add(model);
                        await _context.SaveChangesAsync();
                    }
                    if (productViewModel.AddColor2)
                    {
                        Colour model = new Colour();
                        model.ProductId = productId;
                        model.Color = "#" + productViewModel.Color2;

                        _context.Colour.Add(model);
                        await _context.SaveChangesAsync();
                    }
                    if (productViewModel.AddColor3)
                    {
                        Colour model = new Colour();
                        model.ProductId = productId;
                        model.Color = "#" + productViewModel.Color3;

                        _context.Colour.Add(model);
                        await _context.SaveChangesAsync();
                    }
                }

                if (productViewModel.fImage != null)
                {
                    string fImageName = SaveImage(productViewModel.fImage, true);
                  //  DeleteImage(fImageName, false, true);
                    Image fImage = new Image { Main = true, Name = fImageName, ProductId = productId };

                    _context.Image.Add(fImage);
                    await _context.SaveChangesAsync();

                    if (productViewModel.images.Count > 0)
                    {
                        foreach (IFormFile image in productViewModel.images)
                        {
                            string imageName = SaveImage(image, true);
                         //   DeleteImage(imageName, false, true);
                            Image newImage = new Image { Main = false, Name = imageName, ProductId = productId };

                            _context.Image.Add(newImage);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else { }
                }

                //SetColorSize(productId, productViewModel);
                Discount discount = new Discount { ProductId = productId, DiscountInCombo = productViewModel.DiscountOnCombo, DiscountOnMulti = productViewModel.DiscontOnMulti };
                _context.Discount.Add(discount);
                await _context.SaveChangesAsync();

                ShippingDetail shippingDetail = new ShippingDetail { ProductId = productId, ShippingCharges = productViewModel.shippingDetail.ShippingCharges, IsFree = productViewModel.shippingDetail.IsFree };
                _context.ShippingDetail.Add(shippingDetail);
                await _context.SaveChangesAsync();

                ProductVideo productVideo = new ProductVideo { ProductId = productId, VideoLink = productViewModel.ProductVideo};
                _context.ProductVideo.Add(productVideo);
                await _context.SaveChangesAsync();

                ProductWarranty productWarranty = new ProductWarranty { ProductId = productId, WarrantyInMonths = productViewModel.WarrantyPeriod };
                _context.ProductWarranty.Add(productWarranty);
                await _context.SaveChangesAsync();

                return RedirectToAction("ProductView");
            }
            else
            {
                productViewModel = new AddProductViewModel();
                productViewModel.Categories = new System.Collections.Generic.List<SelectListItem>();
                productViewModel.ProductSize = new List<Size>();

                productViewModel.ProductSize = _context.Size.ToList();
                var categories = _context.Category.Where(c => c.ParentId == null).ToList();
                foreach (var category in categories)
                {
                    var group = new SelectListGroup { Name = category.Name };
                    foreach (var subCategory in category.InverseParents)
                    {
                        if (subCategory.ParentId != null)
                        {
                            var selectListItem = new SelectListItem()
                            {
                                Text = subCategory.Name,
                                Value = subCategory.Id.ToString(),
                                Group = group
                            };
                            productViewModel.Categories.Add(selectListItem);
                        }
                    }
                }
                return View("AddProduct", productViewModel);
            }
        }

        [HttpGet]
        [Route("addRecommendation")]
        public IActionResult AddRecommendation()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {
                var addCombo = new AddRecommendationViewModel();
                addCombo.Categories = new List<SelectListItem>();
                addCombo.productsList = new List<SelectListItem>();
                addCombo.optionalProductsList = new List<SelectListItem>();
                addCombo.productsList.Insert(0, (new SelectListItem { Text = "Choice Product", Value = "0" }));
                addCombo.optionalProductsList.Insert(0, (new SelectListItem { Text = "Choice Product(Optional)", Value = "0" }));
                addCombo.NormalCategories = new List<SelectListItem>();

                var categories = _context.LifeStyleCategory.ToList();

                foreach (var category in categories)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString(),
                    };
                    addCombo.Categories.Add(selectListItem);
                }

                var c = _context.ComboCategory.ToList();
                foreach (var category in c)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString(),
                    };
                    addCombo.NormalCategories.Add(selectListItem);
                }

                var products = _context.Products.Where(p=>p.Status && p.VendorId == userId).ToList();

                foreach (var product in products)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = product.Name,
                        Value = product.Id.ToString(),
                    };
                    addCombo.productsList.Add(selectListItem);
                    addCombo.optionalProductsList.Add(selectListItem);
                }

                return View("AddRecommendation", addCombo);
            }
            catch (Exception e)
            {
                throw;
            }                            
        }

        [HttpPost]
        [Route("addRecommendation")]
        public async Task<IActionResult> AddRecommendation(AddRecommendationViewModel comboViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                List<int> products = new List<int>();

                if (comboViewModel.ProductId1 != 0)
                {
                    products.Add(comboViewModel.ProductId1);
                }
                if (comboViewModel.ProductId2 != 0)
                {
                    products.Add(comboViewModel.ProductId2);
                }
                if (comboViewModel.ProductId3 != 0)
                {
                    products.Add(comboViewModel.ProductId3);
                }
                if (comboViewModel.ProductId4 != 0)
                {
                    products.Add(comboViewModel.ProductId4);
                }
                if (comboViewModel.ProductId5 != 0)
                {
                    products.Add(comboViewModel.ProductId5);
                }

                if (products.Count() > 1)
                {
                    comboViewModel.Recommendation.VendorId = userId;

                    _context.ComboRecommendation.Add(comboViewModel.Recommendation);
                    await _context.SaveChangesAsync();

                    var comboId = comboViewModel.Recommendation.Id;

                    foreach (var Id in products)
                    {
                        ComboProduct model = new ComboProduct();
                        model.ProductId = Id;
                        model.RecommendationId = comboId;

                        _context.ComboProduct.Add(model);
                        await _context.SaveChangesAsync();
                    }
                }   
                return RedirectToAction("ProductView");
            }
            else
            {
                var addCombo = new AddRecommendationViewModel();
                addCombo.Categories = new List<SelectListItem>();
                addCombo.productsList = new List<SelectListItem>();
                addCombo.optionalProductsList = new List<SelectListItem>();
                addCombo.productsList.Insert(0, (new SelectListItem { Text = "Choice Product", Value = "0" }));
                addCombo.optionalProductsList.Insert(0, (new SelectListItem { Text = "Choice Product(Optional)", Value = "0" }));

                addCombo.NormalCategories = new List<SelectListItem>();

                var categories = _context.LifeStyleCategory.ToList();

                foreach (var category in categories)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = category.Name,
                        Value = category.Id.ToString(),
                    };
                    addCombo.Categories.Add(selectListItem);
                }

                var c = _context.Category.ToList();
                foreach (var category in c)
                {
                    var group = new SelectListGroup { Name = category.Name };
                    foreach (var subCategory in category.InverseParents)
                    {
                        if (subCategory.ParentId != null)
                        {
                            var selectListItem = new SelectListItem()
                            {
                                Text = subCategory.Name,
                                Value = subCategory.Id.ToString(),
                                Group = group
                            };
                            addCombo.NormalCategories.Add(selectListItem);
                        }
                    }
                }

                var products = _context.Products.Where(p=>p.Status).ToList();

                foreach (var product in products)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = product.Name,
                        Value = product.Id.ToString(),
                    };
                    addCombo.productsList.Add(selectListItem);
                }
                return View("AddRecommendation", addCombo);
            }
        }

        [HttpGet]
        [Route("addStore")]
        public IActionResult AddStore()
        {
            return View();
        }

        [HttpPost]
        [Route("addStore")]
        public async Task<IActionResult> AddStore(AddStoreViewModel storeViewModel)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Vendor store = new Vendor();

                store.VendorId = userId;
                store.StoreName = storeViewModel.StoreName;
                store.TagLine = storeViewModel.TagLine;
                store.Description = storeViewModel.Description;

                if (storeViewModel.Logo != null)
                {
                    string logoName = SaveImage(storeViewModel.Logo, false);
                    store.Logo = logoName;
                }
    
                if (storeViewModel.Banner != null)
                {
                    string bannarName = SaveImage(storeViewModel.Banner, false);
                    store.Banner = bannarName;
                }

                _context.Vendors.Add(store);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View("AddStore");
            }
        }

        public IActionResult OrderR()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            VendorOrderViewModel model = new VendorOrderViewModel();

            model.OrderList = OrderView(userId);

            List<SelectListItem> status = new List<SelectListItem>();

            var orderStatuses = _context.OrderStatus.ToList();

            foreach (var orderStatus in orderStatuses)
            {
                var selectListItem = new SelectListItem()
                {
                    Text = orderStatus.Name,
                    Value = orderStatus.Id.ToString(),
                };
                status.Add(selectListItem);

            }

            ViewBag.Status = status;

            return View(model);
        }

        [HttpGet]
        [Route("editstore")]
        public IActionResult EditStore()
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

                var store = _context.Vendors.Find(userId);

                AddStoreViewModel model = new AddStoreViewModel();

                model.LogoName = store.Logo;
                model.BannarName = store.Banner;
                model.StoreName = store.StoreName;
                model.TagLine = store.TagLine;
                model.Description = store.Description;

                return View("EditStore", model);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("editstore")]
        public async Task<IActionResult> EditStore(AddStoreViewModel updateStore)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Vendor store = _context.Vendors.Find(userId);

                store.StoreName = updateStore.StoreName;
                store.TagLine = updateStore.TagLine;
                store.Description = updateStore.Description;

                if (updateStore.Logo != null)
                {
                    DeleteImage(store.Logo, false, false);
                    string logoName = SaveImage(updateStore.Logo, false);
                    store.Logo = logoName;
                }
                if (updateStore.Banner != null)
                {
                    string bannarName = SaveImage(updateStore.Banner, false);
                    store.Banner = bannarName;
                }

                _context.Vendors.Update(store);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                var store = _context.Vendors.Find(userId);

                AddStoreViewModel model = new AddStoreViewModel();

                model.LogoName = store.Logo;
                model.BannarName = store.Banner;
                model.StoreName = store.StoreName;
                model.TagLine = store.TagLine;
                model.Description = store.Description;

                return View("EditStore", model);
            }
        }

        public IActionResult OrderDetailV(int Id)
        {
            var details = _context.OrdersDetail.Where(p => p.OrderId == Id).ToList();

            OrderDetailsViewModel orderDetail = new OrderDetailsViewModel();

            orderDetail.OrderId = Id;

            List<OrderDetail> order = new List<OrderDetail>();

            foreach (var detail in details)
            {
                order.Add(detail);
            }
            orderDetail.OrderDetail = order;
            orderDetail.ShippingDetail = GetShippingDetail(Id);
            orderDetail.CustomerDetail = GetCustomerDetail(Id);
            orderDetail.ShippingTracker = _context.ShippingTrackers.Find(Id);

            return View(orderDetail);
        }

        public List<OrderViewModel> OrderView(string userId) 
        {
            List<OrderViewModel> orderView = new List<OrderViewModel>();

            var orders = _context.Order.Where(p => p.VendorId == userId).OrderByDescending(p=>p.Id);

            foreach (var order in orders)
            {
                OrderViewModel model = new OrderViewModel();

                model.OrderId = order.Id;
                model.Date = order.DateCreation;
                model.Name = GetCustomer(order.CustomerId);
                model.StatusId = order.OrderStatusId;

                orderView.Add(model);
            }

            return orderView;
        }

        [Route("updatestatus")]
        [HttpPost]
        public async Task<IActionResult> UpdateStatus(IFormCollection fc)
        {
            int Id = Convert.ToInt32(fc["Id"]);

            int StatusId = Convert.ToInt32(fc["StatusId"]);

            var item = _context.Order.Find(Id);

            item.OrderStatusId = StatusId;

            _context.Order.Update(item);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Message()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var messages = _context.Message.Where(p => p.VendorId == userId && p.SenderCustomer== true).OrderByDescending(o => o.DateCreation).ToList();

            MessageListViewModel model = new MessageListViewModel();

            model.Messages = messages;

            return View(model);
        }

        public IActionResult MessageDetail(int Id)
        {
            var message = _context.Message.Find(Id);

            message.Status = true;
            _context.Message.Update(message);
            _context.SaveChangesAsync();

            return View(message);
        }

        [Route("sendCMessage")]
        [HttpGet]
        public IActionResult SendCMessage(int Id)
        {
            try
            {
                Message message = new Message();
                message.OrderId = Id;
                return View(message);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [Route("sendCMessage")]
        [HttpPost]
        public async Task<IActionResult> SendCMessage(Message message)
        {
            var order = _context.Order.Find(message.OrderId);

            if (ModelState.IsValid)
            {
                Message model = new Message();
                model.OrderId = order.Id;
                model.Title = message.Title;
                model.Body = message.Body;
                model.CustomerId = order.CustomerId;
                model.VendorId = order.VendorId;
                model.DateCreation = DateTime.Now.Date;
                model.SenderCustomer = false;
                model.Status = false;

                _context.Message.Add(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("SendedMSuccessfully");
            }
            else
            {
                Message m = new Message();
                m.OrderId = order.Id;
                return View(m);
            }
        }

        public IActionResult SendedMSuccessfully()
        {
            return View();
        }

        [Route("addTracking")]
        [HttpPost]
        public async Task<IActionResult> AddTracking(IFormCollection fc)
        {
            int Id = Convert.ToInt32(fc["orderId"]);

            string TrackingNumber = fc["trackingNumber"];

            string CompanyName = fc["companyName"];

            var tracking = _context.ShippingTrackers.Find(Id);

            if(tracking != null)
            {
                ShippingTracker model = new ShippingTracker();
                model = tracking;
                model.TrackingNumber = TrackingNumber;
                model.CompanyName = CompanyName;

                _context.ShippingTrackers.Update(model);
                await _context.SaveChangesAsync();
            }
            else
            {
                ShippingTracker model = new ShippingTracker();
                model.TrackingNumber = TrackingNumber;
                model.OrderId = Id;
                model.CompanyName = CompanyName;

                _context.ShippingTrackers.Add(model);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public string GetStatus(int Id)
        {
            var status = _context.OrderStatus.Find(Id);

            return status.Name;
        }

        public string GetCustomer(string Id)
        {
            var customer = _context.Account.Where(p => p.UserId == Id);

            var name = "";

            foreach (var c in customer)
            {
                name = c.FullName;
            }

            return name;
        }

        public Address GetShippingDetail(int orderId)
        {
            var order = _context.Order.Find(orderId);

            var address = _context.Address.Where(p => p.UserId == order.CustomerId).ToList();

            Address shippingAddress = new Address();

            foreach(var a in address)
            {
                shippingAddress = a;
            }

            return shippingAddress;
        }
        
        public Account GetCustomerDetail(int orderId)
        {
            var order = _context.Order.Find(orderId);
            var account = _context.Account.Find(order.CustomerId);

            return account;
        }

        public IActionResult DeleteRcommentation(int Id)
        {
            var comboProducts = _context.ComboProduct.Where(p => p.RecommendationId == Id).ToList();

            foreach(var product in comboProducts)
            {
                _context.ComboProduct.Remove(product);
                _context.SaveChangesAsync();
            }
            var recommandation = _context.ComboRecommendation.Find(Id);
            _context.ComboRecommendation.Remove(recommandation);
            _context.SaveChangesAsync();

            return View("ProductView");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var images = _context.Image.Where(p => p.ProductId == Id).ToList();

            if (images != null)
            {
                foreach (var image in images)
                {
                    DeleteImage(image.Name, true, false);
                    _context.Image.Remove(image);
                    await _context.SaveChangesAsync();
                }
            }

            var discount = _context.Discount.FirstOrDefault(p => p.ProductId == Id);

            if (discount != null)
            {
                _context.Discount.Remove(discount);
                await _context.SaveChangesAsync();
            }

            var shipping = _context.ShippingDetail.Find(Id);

            if (shipping != null)
            {
                _context.ShippingDetail.Remove(shipping);
                await _context.SaveChangesAsync();
            }

            var video = _context.ProductVideo.Find(Id);
            if (video != null)
            {
                _context.ProductVideo.Remove(video);
                await _context.SaveChangesAsync();
            }

            var review = _context.Reviews.Where(p => p.ProductId == Id).ToList();
            if (review != null)
            {
               _context.Reviews.RemoveRange(review);
               await _context.SaveChangesAsync();
            }
            var colors = _context.Colour.Where(p => p.ProductId == Id).ToList();
            if (colors != null)
            {
                _context.Colour.RemoveRange(colors);
                await _context.SaveChangesAsync();
            }
            var sizes = _context.ProductSize.Where(p => p.ProductId == Id).ToList();
            if (sizes != null)
            {
                _context.ProductSize.RemoveRange(sizes);
                await _context.SaveChangesAsync();
            }

            var warranty = _context.ProductWarranty.Find(Id);
            if (warranty != null)
            {
                _context.ProductWarranty.Remove(warranty);
                await _context.SaveChangesAsync();
            }

            DeleteRcommentationRecort(Id);
          
                var product = _context.Products.Find(Id);

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

            return RedirectToAction("ProductView");
        }

        [HttpGet]
        [Route("editProduct")]
        public IActionResult EditProduct(int Id)
        {
            try
            {
                var addProduct = new EditProductViewModel();
                addProduct.Categories = new List<SelectListItem>();
                var categories = _context.Category.ToList();
                addProduct.ComboCategories = new List<SelectListItem>();

                foreach (var category in categories)
                {
                    var group = new SelectListGroup { Name = category.Name };
                    foreach (var subCategory in category.InverseParents)
                    {
                        if (subCategory.ParentId != null)
                        {

                            var selectListItem = new SelectListItem()
                            {
                                Text = subCategory.Name,
                                Value = subCategory.Id.ToString(),
                                Group = group
                            };
                            addProduct.Categories.Add(selectListItem);
                        }
                    }
                }

                var combocategories = _context.LifeStyleCategory.ToList();

                foreach (var c in combocategories)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                    };
                    addProduct.ComboCategories.Add(selectListItem);
                }

                var p = _context.Products.Find(Id);

                Product model = new Product();
                model.Id = p.Id;
                model.Name = p.Name;
                model.CategoryId = p.CategoryId;
                if (p.LifeStyleCategoryId != 0)
                {
                    model.LifeStyleCategoryId = p.LifeStyleCategoryId;
                }
                else
                {
                    model.LifeStyleCategoryId = 1;
                }
                model.Description = p.Description;
                model.Price = p.Price;
                model.Quantity = p.Quantity;
                addProduct.product = model;

                var discount = _context.Discount.Where(c => c.ProductId == p.Id).ToList();
                foreach (var d in discount)
                {
                    addProduct.DiscountOnCombo = d.DiscountInCombo;
                    addProduct.DiscontOnMulti = d.DiscountOnMulti;
                }

                addProduct.ProductVideo = _context.ProductVideo.FirstOrDefault(c => c.ProductId == p.Id).VideoLink;

                return View("EditProduct", addProduct);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("editProduct")]
        public async Task<IActionResult> EditProduct(EditProductViewModel updateProduct)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                Product product = _context.Products.Find(updateProduct.ProductId);

                product.Name = updateProduct.product.Name;
                product.Description = updateProduct.product.Description;
                product.Price = updateProduct.product.Price;
                product.Quantity = updateProduct.product.Quantity;
                product.CategoryId = updateProduct.product.CategoryId;
                product.LifeStyleCategoryId = updateProduct.product.LifeStyleCategoryId;

                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();

                var video = _context.ProductVideo.Find(product.Id);

                if(updateProduct.ProductVideo != null)
                {
                    if(video != null)
                    {
                        _context.ProductVideo.Remove(video);
                    }

                    ProductVideo productVideo = new ProductVideo { ProductId = product.Id, VideoLink = updateProduct.ProductVideo };

                    _context.ProductVideo.Add(productVideo);
                    await _context.SaveChangesAsync();
                }

                var images = _context.Image.Where(p => p.ProductId == product.Id).ToList();

                    if (updateProduct.fImage != null)
                    {
                        var f = images.FirstOrDefault(p => p.Main == true);
                        DeleteImage(f.Name, true, false);
                        _context.Image.Remove(f);

                        string fImageName = SaveImage(updateProduct.fImage, true);
                        Image fImage = new Image { Main = true, Name = fImageName, ProductId = updateProduct.ProductId };
                        _context.Image.Add(fImage);
                        if (updateProduct.images.Count > 0)
                        {
                            foreach (var image in images)
                            {
                                DeleteImage(image.Name, true, false);
                            }
                            foreach (IFormFile image in updateProduct.images)
                            {
                                string imageName = SaveImage(image, true);
                                Image newImage = new Image { Main = false, Name = imageName, ProductId = updateProduct.ProductId };
                                _context.Image.Add(newImage);
                            }
                        }
                        else { }

                        await _context.SaveChangesAsync();
                    }

                    var currentDiscount = _context.Discount.FirstOrDefault(p => p.ProductId == updateProduct.ProductId);

                    currentDiscount.DiscountInCombo = updateProduct.DiscountOnCombo;
                    currentDiscount.DiscountOnMulti = updateProduct.DiscontOnMulti;

                    _context.Discount.Update(currentDiscount);
                    await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                var addProduct = new EditProductViewModel();
                addProduct.Categories = new List<SelectListItem>();
                var categories = _context.Category.ToList();

                foreach (var category in categories)
                {
                    var group = new SelectListGroup { Name = category.Name };
                    foreach (var subCategory in category.InverseParents)
                    {
                        if (subCategory.ParentId != null)
                        {
                            var selectListItem = new SelectListItem()
                            {
                                Text = subCategory.Name,
                                Value = subCategory.Id.ToString(),
                                Group = group
                            };
                            addProduct.Categories.Add(selectListItem);
                        }
                    }
                }

                var combocategories = _context.LifeStyleCategory.ToList();

                foreach (var c in combocategories)
                {
                    var selectListItem = new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.Id.ToString(),
                    };
                    addProduct.ComboCategories.Add(selectListItem);
                }
                var p = _context.Products.Find(updateProduct.ProductId);

                Product model = new Product();
                model.Name = p.Name;
                model.CategoryId = p.CategoryId;
                model.Description = p.Description;
                model.Price = p.Price;
                model.Quantity = p.Quantity;
                addProduct.product = model;

                var discount = _context.Discount.Where(c => c.ProductId == p.Id).ToList();
                foreach (var d in discount)
                {
                    addProduct.DiscountOnCombo = d.DiscountInCombo;
                    addProduct.DiscontOnMulti = d.DiscountOnMulti;
                }

                addProduct.ProductVideo = _context.ProductVideo.FirstOrDefault(c => c.ProductId == p.Id).VideoLink;
    
                return View("EditProduct", addProduct);
            }
        }

        public string SaveImage(IFormFile image, bool IsProduct)
        {
            string uniqueFileName = "";

            if (IsProduct)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "preprocessimages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                string imgext = Path.GetExtension(image.FileName);

                if (imgext == ".png")
                {
                    string uploadsFile = Path.Combine(hostingEnvironment.WebRootPath, "productimages");
                    string path = Path.Combine(uploadsFile, uniqueFileName);
                    var fileStream = new FileStream(path, FileMode.Create);
                    image.CopyTo(fileStream);
                    OptimizeImage(uniqueFileName, true);
                }
                else
                {
                    if (image != null && image.Length > 0 && image.ContentType.Contains("image"))
                    {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(fileStream);
                    OptimizeImage(uniqueFileName, false);
                    }
                }
            }
            else
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "storeimages");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                string imgext = Path.GetExtension(image.FileName);

                if (image != null && image.Length > 0 && image.ContentType.Contains("image"))
                {
                    var fileStream = new FileStream(filePath, FileMode.Create);
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public void OptimizeImage(string imageName, bool IsPNG)
        {
            string preprocessFolder = Path.Combine(hostingEnvironment.WebRootPath, "preprocessimages");
            string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "productimages");
            string uploads = Path.Combine(preprocessFolder, imageName);
            string delete = Path.Combine(preprocessFolder, imageName);
            string save = Path.Combine(uploadsFolder, imageName);
            if (IsPNG)
            {         
                //PngOptimizer optimizer = new PngOptimizer();
                //var i = new FileInfo(save);
                //optimizer.LosslessCompress(i);
                //i.Refresh();
            }
            else
            {
                using (MagickImage image = new MagickImage(uploads))
                {
                    image.Resize(400, 0);
                    image.Write(save);
                }

                var i = new FileInfo(save);
                var optimizer = new ImageOptimizer();
                optimizer.LosslessCompress(i);
                i.Refresh();
            }
        }

        private byte[] ConvertImageToByteArray(IFormFile image)
        {
            byte[] result = null;

            // filestream
            using (var fileStream = image.OpenReadStream())

            // memory stream
            using (var memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0; // The position needs to be reset.

                var before = memoryStream.Length;

                //ImageOptimizer optimizer = new ImageOptimizer();
               // optimizer.LosslessCompress(memoryStream);

                var after = memoryStream.Length;

                // convert to byte[]
                result = memoryStream.ToArray();
            }
            return result;
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

        public void DeleteImage(string image, bool IsProduct, bool IsUpload)
        {     
            if (IsProduct || IsUpload)
            {
                if (IsUpload)
                {
                    string _imagePath = Path.Combine(hostingEnvironment.WebRootPath, "preprocessimages\\", image);
                    if ((System.IO.File.Exists(_imagePath)))
                    {
                        System.IO.File.Delete(_imagePath);
                    }
                }
                else
                {
                    string _imagePath = Path.Combine(hostingEnvironment.WebRootPath, "productimages\\", image);
                    if ((System.IO.File.Exists(_imagePath)))
                    {
                        System.IO.File.Delete(_imagePath);
                    }
                }
            }
            else
            {
                string _imagePath = Path.Combine(hostingEnvironment.WebRootPath, "storeimages\\", image);
                if ((System.IO.File.Exists(_imagePath)))
                {
                    System.IO.File.Delete(_imagePath);
                }
            }
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

        public double GetDiscountTotal(int Id, double price)
        {
            var discount = _context.Discount.Where(p => p.ProductId == Id).ToList();
            double newPrice = 0;
            foreach (var d in discount)
            {
                newPrice = price - price * d.DiscountInCombo / 100;
            }
            return newPrice;
        }

        public double GetTotalEarning(string userId)
        {
            var orders = _context.Order.Where(p => p.VendorId == userId).ToList();

            double total = 0;

            foreach(var order in orders)
            {
                var orderDetail = _context.OrdersDetail.Where(p => p.OrderId == order.Id).ToList();

                total += GetTotal(orderDetail);
            }

            return total;
        }

        public double GetTotal(List<OrderDetail> products)
        {
            double total = 0;
            foreach(var product in products)
            {
                total += product.TotalPrice;
            }

            return total;
        }

        public void DeleteRcommentationRecort(int productId)
        {
            var combos = _context.ComboProduct.Where(p => p.ProductId == productId).ToList();

            if(combos.Count() != 0)
            {
                int Id = 0;
                foreach(var combo in combos)
                {
                    Id = combo.RecommendationId;
                    _context.ComboProduct.Remove(combo);
                    _context.SaveChangesAsync(); 
                }

                var comboR = _context.ComboRecommendation.Find(Id);
                
                _context.ComboRecommendation.Remove(comboR);
                _context.SaveChangesAsync();
            }
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

        public async void SetColorSize(int productId, AddProductViewModel info)
        {
            if (!info.product.ColorNotApplicable)
            {
                SetColor(productId, info.Color1, info.AddColor1) ;
                SetColor(productId, info.Color2, info.AddColor2);
                SetColor(productId, info.Color3, info.AddColor3);

            }

            if (!info.product.SizeNotApplicable)
            {
                //if (info.Size.XS)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "XS";
                //     _context.ProductSize.Add(model);
                //}
                //if (info.Size.S)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "S";
                //    _context.ProductSize.Add(model);
                //}
                //if (info.Size.M)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "M";
                //    _context.ProductSize.Add(model);
                //}
                //if (info.Size.L)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "L";
                //    _context.ProductSize.Add(model);
                //}
                //if (info.Size.XL)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "XL";
                //    _context.ProductSize.Add(model);
                //}
                //if (info.Size.XXL)
                //{
                //    ProductSize model = new ProductSize();
                //    model.ProductId = productId;
                //    model.ItemSize = "XXL";
                //    _context.ProductSize.Add(model);
                //}

                //_context.SaveChangesAsync();
            }
        }

        public void SetColor(int productId, string color, bool add)
        {
            if (add)
            {
                Colour model = new Colour();
                model.ProductId = productId;
                model.Color = "#"+color;
                _context.Colour.Add(model);
                _context.SaveChangesAsync();
            }
        }
    }
} 
