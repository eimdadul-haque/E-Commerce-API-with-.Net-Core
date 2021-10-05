using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Data;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;
using OnlineShop_API.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Repository
{

    public class OrederRepository : IOrederRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public OrederRepository(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        
        public async Task<List<OrderModel>> GetAllOrder()
        {
            return await _db.orderModel.Include(c=>c.orderDetails).ThenInclude(c=>c.Product).ToListAsync();
        }

        public async Task<OrderModel> GetOneOrder(int? id)
        {
            return await _db.orderModel.Include(c => c.orderDetails).ThenInclude(c=>c.Product).FirstOrDefaultAsync(c=>c.Id == id);
             
        }

        
        public async Task ReceiveOrder(OrderViewModels order)
        {
            var orderModel = new OrderModel
            {
                UserId = order.UserId,
                Id = order.OrderId,
                Name = order.Name,
                Email = order.Email,
                Phone = order.Phone,
                Address = order.Address
            };

            await _db.orderModel.AddAsync(orderModel);
            await _db.SaveChangesAsync();
            _db.Entry(orderModel).GetDatabaseValues();
            if (orderModel.Id != 0)
            {
               await OrderDetails(orderModel.Id, order);
            }
        }

        public async Task OrderDetails(int id, OrderViewModels Order)
        {
            foreach (var item in Order.Products)
            {
                var details = new OrderDetailsModel
                {
                    OrderId = id,
                    ProductId = item.id,
                    Qty = item.Qty
                };
                await _db.orderDetailsModel.AddAsync(details);
                await _db.SaveChangesAsync();
                _db.ChangeTracker.Clear();
            }
           
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
