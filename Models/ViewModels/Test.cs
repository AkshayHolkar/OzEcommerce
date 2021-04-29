using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class Test
    {
        public int Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public int categoryId { get; set; }
        public IFormFile fImage { get; set; }
        public List<IFormFile> images { get; set; }
        public List<SelectListItem> Categories { get; set; }
    }
}
