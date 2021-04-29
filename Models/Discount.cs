using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int DiscountInCombo { get; set; }
        public int DiscountOnMulti { get; set; }
        public virtual Product Product { get; set; }
    }
}
