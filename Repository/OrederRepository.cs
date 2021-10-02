using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Data;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Repository
{

    public class OrederRepository : IOrederRepository
    {
        private readonly ApplicationDbContext _db;

        public OrederRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<OrderModel>> GetAllOrder()
        {
            return  await _db.orderModel.ToListAsync();
        }

        public async Task<OrderModel> GetOneOrder(int? id)
        {
            return await _db.orderModel.FindAsync(id);
             
        }

        public async Task ReceiveOrder(OrderModel order)
        {
            await _db.orderModel.AddAsync(order);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteOrder(int? id)
        {
             _db.orderModel.Remove(await GetOneOrder(id));
            await _db.SaveChangesAsync();
        }

        public string Status(int code)
        {
            switch (code)
            {
                case 0:
                    return "Decline";
                case 1:
                    return "Confirem";
                case 2:
                    return "shiping";
                default:
                    return "-1";
            }
        }

    }
}
