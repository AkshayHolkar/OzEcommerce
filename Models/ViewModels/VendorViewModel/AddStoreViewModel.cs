using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels.VendorViewModel
{
    public class AddStoreViewModel
    {
        public IFormFile Logo { get; set; }
        public string LogoName { get; set; }
        public IFormFile Banner { get; set; }
        public string BannarName { get; set; }
        public string StoreName { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
    }
}
