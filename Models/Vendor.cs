  using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Vendor")]
    public partial class Vendor
    {
        public string Id { get; set; }
        public string VendorId { get; set; }
        public string StoreName { get; set; }
        public string TagLine { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Banner { get; set; }
        public ApplicationUser User { get; set; }

    }
}
