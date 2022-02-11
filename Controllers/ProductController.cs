using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShop_API.Data;
using OnlineShop_API.Models;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<ProductModel>>> Get()
        {
            return Ok(await _db.productD.Include(c=>c.productType).ToListAsync());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductModel>> Get(int id)
        {
            return Ok(await _db.productD.FindAsync(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductModel productModel )
        {
            if (ModelState.IsValid)
            {
               await _db.productD.AddAsync(productModel);
                await _db.SaveChangesAsync();
                return Ok("Ok");
            }
            return Ok("Model not valid");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _db.productD.Update(productModel);
                await _db.SaveChangesAsync();
                return Ok("Ok");
            }

            return Ok("Model not valid");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await _db.productD.FindAsync(id);
            if (item != null)
            {
                _db.productD.Remove(item);
                await _db.SaveChangesAsync();
                return Ok("Ok");
            }
            return Ok("Product not found");
        }
    }
}
