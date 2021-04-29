using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class AddRecommendationViewModel
    {
        public ComboRecommendation Recommendation { get; set; }
        public int ProductId1 { get; set; }
        public int ProductId2 { get; set; }
        public int ProductId3 { get; set; }
        public int ProductId4 { get; set; }
        public int ProductId5 { get; set; }
        public List<SelectListItem> productsList { get; set; }
        public List<SelectListItem> optionalProductsList { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> NormalCategories { get; set; }
    }
}
