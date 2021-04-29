using System.ComponentModel.DataAnnotations.Schema;


namespace OzEcommerceV14.Models
{
    [Table("ProductSize")]
    public partial class ProductSize
    {
        public int Id { get; set; }
        public int ProductId{ get; set; }
        public string ItemSize { get; set; }
        public virtual Product Product { get; set; }
    }
}
