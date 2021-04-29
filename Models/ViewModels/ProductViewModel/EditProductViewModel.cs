using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.ProductViewModel
{
    public class EditProductViewModel
    {
        public Product product { get; set; }
        public int ProductId { get; set; }
        public IFormFile fImage { get; set; }
        public List<IFormFile> images { get; set; }
        public string ProductVideo { get; set; }
        public int DiscountOnCombo { get; set; }
        public int DiscontOnMulti { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> ComboCategories { get; set; }

    }
}
