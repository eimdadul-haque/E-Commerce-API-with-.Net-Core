using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop_API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string description { get; set; }
 
        [Required]
        public string price { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;

        public string imageName { get; set; }

        [Required]
        public int productTypeId { get; set; }

        [ForeignKey("productTypeId")]
        public ProductTypeModel? productType { get; set; }

    }
}
