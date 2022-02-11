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
            return Ok(await _context.productD.Include(c=>c.productType).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> get([FromRoute]int id)
        {
            return Ok(await _context.productD.FindAsync(id));
        }


        [HttpGet("prduct-category")]
        public async Task<ActionResult<List<ProductModel>>> prductByCategory([FromQuery] string category)
        {
            if (category != null)
            {
                return Ok( await _context.productD.Where(c => c.productType.type == category).ToListAsync());
            }
            return BadRequest();
        }

        [HttpGet("search")]
        public async Task<ActionResult<List<ProductModel>>> search(string query)
        {
            return Ok(_context.productD.Select(x => x.name.Contains(query)));
        }
    }
}
