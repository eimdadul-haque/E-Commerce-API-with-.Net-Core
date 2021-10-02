using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<ProductModel> products { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
}
