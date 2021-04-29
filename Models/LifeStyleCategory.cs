using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("LifeStyleCategory")]
    public partial class LifeStyleCategory
    {
        public LifeStyleCategory()
        {
            ComboRecommendations = new HashSet<ComboRecommendation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ComboRecommendation> ComboRecommendations { get; set; }
    }
}
