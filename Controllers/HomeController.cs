using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Data;
using OnlineShop_API.Models;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<ProductModel>>> get()
        {
            return Ok(await _context.productD.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> get([FromRoute]int id)
        {
            return Ok(await _context.productD.FindAsync(id));
        }
    }
}
