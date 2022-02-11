using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Data;
using OnlineShop_API.Models;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> get()
        {
            return Ok(await _context.productTypeD.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> get([FromRoute] int id)
        {
            return Ok(await _context.productTypeD.FindAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult> post([FromBody] ProductTypeModel productType)
        {
            if (ModelState.IsValid)
            {
                await _context.productTypeD.AddAsync(productType);
                await _context.SaveChangesAsync();
                return Ok("Ok");
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<ActionResult> put([FromForm] ProductTypeModel productType)
        {
            if (ModelState.IsValid)
            {
                _context.productTypeD.Update(productType);
                await _context.SaveChangesAsync();
                return Ok("Ok");
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete([FromRoute] int id)
        {
            if (id != null)
            {
                var item = await _context.productTypeD.FindAsync(id);
                _context.productTypeD.Remove(item);
                await _context.SaveChangesAsync();
                return Ok("Ok");
            }

            return BadRequest();
        }
    }
}
