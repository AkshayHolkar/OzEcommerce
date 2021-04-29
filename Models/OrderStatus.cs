using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OzEcommerceV14.Models
{
    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
