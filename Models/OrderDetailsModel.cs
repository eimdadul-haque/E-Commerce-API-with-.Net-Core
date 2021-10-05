using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop_API.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public OrderModel Order { get; set;}
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
        public int Qty { get; set; }
    }
}
