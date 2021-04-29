using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public double OriginalTotal { get; set; }
        public double TotalPrice { get; set; }
        public int Quantity { get; set; }
        public double ShippingCharge { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
