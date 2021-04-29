using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzEcommerceV14.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.ViewComponents
{
    [ViewComponent(Name = "Cart")]
    public class CartViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartViewComponent(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            ViewBag.carts = _context.Cart.Where(p => p.CustomerId == userId).ToList();

            return View("Index");
        }
    }
}
