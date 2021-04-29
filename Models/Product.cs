using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Photos = new HashSet<Image>();

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public int LifeStyleCategoryId { get; set; }
        public string VendorId { get; set; }
        public int Views { get; set; }
        public bool SizeNotApplicable { get; set; }
        public bool ColorNotApplicable { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser  User { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ShippingDetail  ShippingDetail { get; set; }
        public virtual ProductVideo ProductVideo { get; set; }
        public virtual ProductWarranty ProductWarranty { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Image> Photos { get; set; }
        public virtual ICollection<Colour> Colour { get; set; }
        public virtual ICollection<ProductSize> ProductSize { get; set; }
        public virtual ICollection<ComboProduct> ComboProduct { get; set; }
    }
}
