using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ComboCategory
    {
        public ComboCategory()
        {
            ComboRecommendations = new HashSet<ComboRecommendation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ComboRecommendation> ComboRecommendations { get; set; }
    }
}
