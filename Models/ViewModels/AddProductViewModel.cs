using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzEcommerceV14.Models.ViewModels.VendorViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class AddProductViewModel
    {
        public Product product { get; set; }

        public IFormFile fImage { get; set; }

        public List<IFormFile> images { get; set; }

        public string ProductVideo { get; set; }

        public int WarrantyPeriod { get; set; }

        public int DiscountOnCombo { get; set; }

        public int DiscontOnMulti { get; set; }

        [BindProperty]
        public List<string> size { get; set; }

        //[BindProperty]
        //public List<string> Color { get; set; } 
        //[BindProperty]
        //public List<bool> Add { get; set; }

        public bool AddColor1 { get; set; }

        public string Color1 { get; set; }

        public bool AddColor2 { get; set; }

        public string Color2 { get; set; }

        public bool AddColor3 { get; set; }

        public string Color3 { get; set; }

        public ShippingDetail shippingDetail { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> ComboCategories { get; set; }

        public List<Size> ProductSize { get; set; }
    }
}
