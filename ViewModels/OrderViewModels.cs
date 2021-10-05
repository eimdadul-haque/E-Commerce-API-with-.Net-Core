using OnlineShop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.ViewModels
{
    public class OrderViewModels
    {
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public List<ProductViewModel> Products { get; set; }
    }

    public class ProductViewModel
    {
        public int id { get; set; }
        public int Qty { get; set; }
    }
}
