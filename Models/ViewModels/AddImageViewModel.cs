using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class AddImageViewModel
    {
        public int productId { get; set; }
        public IFormFile fImage { get; set; }
        public List<IFormFile> images { get; set; }
    }
}
