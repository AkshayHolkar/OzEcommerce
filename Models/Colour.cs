using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace OzEcommerceV14.Models
{
    [Table("Colour")]
    public partial class Colour
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Color { get; set; }
        public virtual Product Product { get; set; }
    }
}
