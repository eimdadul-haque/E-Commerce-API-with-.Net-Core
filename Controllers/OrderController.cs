using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;
using OnlineShop_API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrederRepository _repo;
     
        public OrderController(IOrederRepository repo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrder()
       {
            return Ok(await _repo.GetAllOrder());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneOrder([FromRoute]int? id)
        {
            if (id != null)
            {
                return Ok(await _repo.GetOneOrder(id));
            }

            return Ok(NoContent());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ReceiveOrder([FromBody]OrderViewModels order)
        {
            if (ModelState.IsValid)
            {
                string userNmae = User.FindFirst(ClaimTypes.Name)?.Value;
                var userInfo = await _userManager.FindByNameAsync(userNmae);
                order.UserId = userInfo.Id;
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
