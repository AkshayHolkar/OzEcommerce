using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime DateCreation { get; set; }
        public string CustomerId { get; set; }
        public string VendorId { get; set; }
        public int OrderStatusId { get; set; }
        public int? PaymentId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ShippingTracker ShippingTracker { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
