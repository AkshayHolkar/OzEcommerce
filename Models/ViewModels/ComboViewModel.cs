using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class ComboViewModel
    {
        public ComboViewModel()
        {
            this.Combo = new List<ComboProductViewModel>();
        }

        public int ComboId;
        public List<ComboProductViewModel> Combo { get; set; }

        public double Total { get; set; }

        public double DiscountTotal { get; set; }


    }
}
