using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Review")]
    public partial class Review
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public string VendorId { get; set; }
        public int Rating { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public DateTime DatePost { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
