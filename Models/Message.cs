using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Message")]
    public partial class Message
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime DateCreation { get; set; }
        public string CustomerId { get; set; }
        public string VendorId { get; set; }
        public int OrderId { get; set; }
        public bool Status { get; set; }
        public bool SenderCustomer { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Order Order { get; set; }
    }
}
