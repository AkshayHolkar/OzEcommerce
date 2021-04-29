using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ComboProduct
    {
        public int Id { get; set; }
        public int RecommendationId { get; set; }
        public int ProductId { get; set; }
        public virtual ComboRecommendation ComboRecommendation { get; internal set; }
        public virtual Product Product { get; internal set; }
    }
}
