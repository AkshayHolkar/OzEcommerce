using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ComboRecommendation
    {
        public int Id { get; set; }
        public string VendorId { get; set; }
        public int LifeStyleCategoryId { get; set; }
        public int ComboCategoryId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ComboCategory ComboCategory { get; set; }
        public virtual LifeStyleCategory LifeStyleCategory { get; set; }
        public virtual ICollection<ComboProduct> ComboProduct { get; set; }
    }
}
