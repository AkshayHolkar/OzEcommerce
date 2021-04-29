using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace OzEcommerceV14.Models
{
    [Table("Payment")]
    public partial class Payment
    {
        public Payment()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
