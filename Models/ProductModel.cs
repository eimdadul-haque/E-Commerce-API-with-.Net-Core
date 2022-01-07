
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShop_API.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string productName { get; set; }

        public int productQty { get; set; }

        public string imageName { get; set; }

        public decimal  productPrice { get; set; }

        public int productTypeId { get; set; }
        [ForeignKey("productTypeId")]
        public ProductTypeModel productType { get; set; }

        [NotMapped]
        public IFormFile productImg { get; set; }
    }
}
