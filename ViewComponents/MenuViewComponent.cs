using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OzEcommerceV14.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OzEcommerceV14.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MenuViewComponent(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Index");
        }
    }
}
