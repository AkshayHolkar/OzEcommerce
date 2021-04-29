using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OzEcommerceV14.Controllers;
using OzEcommerceV14.Data;
using OzEcommerceV14.Models;

namespace OzEcommerceV14.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly ApplicationDbContext _context;


        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {

            RemoveAllCarts();
            

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }

        public void RemoveAllCarts()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<Cart> carts = new List<Cart>();

            if (User.IsInRole("Vendor"))
            {
                carts = _context.Cart.Where(p => p.VendorId == userId).ToList();

            }
            else
            {
                carts = _context.Cart.Where(p => p.CustomerId == userId).ToList();
            }
          



            foreach (var c in carts)
            {
                _context.Remove(c);
                _context.SaveChangesAsync();
            }


        }

        public void UpdateQuantity(int productId, int Quantity)
        {
            var product = _context.Products.Find(productId);

            Product model = new Product();
            model = product;
            model.Quantity = product.Quantity + Quantity;

            _context.Products.Update(model);
            _context.SaveChangesAsync();
        }
    }
}
