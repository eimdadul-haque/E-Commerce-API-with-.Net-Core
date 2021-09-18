using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.getAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute]int id)
        {
            return Ok(await _repo.getOneProduct(id));
        }


        [HttpPost]
       // [Authorize]
        public async Task<IActionResult> AddProduct([FromBody] ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _repo.addProduct(product);
                return Ok();
            }

            return Ok(ModelState);
        }

        [HttpPut]
       // [Authorize]
        public async Task<IActionResult> EditProduct([FromBody]ProductModel product)
        {
            if (ModelState.IsValid)
            {
                await _repo.editProduct(product);
                return Ok();
            }

            return Ok(ModelState);
        }

      //  [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            if (ModelState.IsValid)
            {
                await _repo.deleteProduct(id);
                return Ok();
            }

            return Ok(ModelState);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery]string query)
        {
            return Ok (await _repo.Search(query));
        }
    }
}
