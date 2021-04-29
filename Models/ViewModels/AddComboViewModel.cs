using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class AddComboViewModel
    {
        public IFormFile fImage { get; set; }
        public List<IFormFile> images { get; set; }
        public List<SelectListItem>  productsList { get; set; }      
        public List<SelectListItem> Categories { get; set; }
    }
}
