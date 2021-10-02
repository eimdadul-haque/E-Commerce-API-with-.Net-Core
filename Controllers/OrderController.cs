using Microsoft.AspNetCore.Mvc;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop_API.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrederRepository _repo;
     
        public OrderController(IOrederRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> GetAllOrder()
        {
            return Ok(await _repo.GetAllOrder());
        }

        public async Task<IActionResult> GetOneOrder(int? id)
        {
            if (id != null)
            {
                return Ok(await _repo.GetOneOrder(id));
            }

            return Ok(NoContent());
        }

        public async Task<IActionResult> ReceiveOrder(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                await _repo.ReceiveOrder(order);
            }
            return Ok();
        }

        public async Task<IActionResult> DeleteOrder(int? id)
        {
            if (id != null)
            {
               await _repo.DeleteOrder(id);
            }

            return Ok(NoContent());
        }
    }
}
