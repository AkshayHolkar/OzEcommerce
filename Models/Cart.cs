using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Cart")]
    public class Cart
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Photo { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double DiscountPrice { get; set; }
        public double ComboPrice { get; set; }
        public int Quantity { get; set; }
        public int MaxLimit { get; set; }
        public string VendorId { get; set; }
        public double OriginalPrice { get; set; }
    }
}
