using OnlineShop_API.Models;
using OnlineShop_API.ViewModels;
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
        Task ReceiveOrder(OrderViewModels order);
        Task DeleteOrder(int? id);
        string Status(int code);
    }
    
}
