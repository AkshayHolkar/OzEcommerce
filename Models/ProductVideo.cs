using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class ProductVideo
    {
        public int ProductId { get; set; }
        public string VideoLink { get; set; }
        public virtual Product Product { get; set; }
    }
}
