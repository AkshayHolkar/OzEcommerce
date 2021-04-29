using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzEcommerceV14.Models
{
    [Table("Image")]
    public partial class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Main { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
