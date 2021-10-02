using OnlineShop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.IRepository
{
    public interface IOrederRepository
    {
        Task<List<OrderModel>> GetAllOrder();
        Task<OrderModel> GetOneOrder(int? id);
        Task ReceiveOrder(OrderModel order);
        Task DeleteOrder(int? id);
        string Status(int code);
    }
    
}
