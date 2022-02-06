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

        public string imageName { get; set; }


    }
}
