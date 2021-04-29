using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models.ViewModels
{
    public class ComboSetViewModel
    {
        public ComboSetViewModel()
        {
            this.comboSet = new List<ComboViewModel>();
        }

        public int LifeStyleId { get; set; }
        public List<ComboViewModel> comboSet { get; set; }
    }
}
