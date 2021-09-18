using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop_API.IRepository;
using OnlineShop_API.Models;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeRepository _repo;
        public ProductTypeController(IProductTypeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.getAllProductType());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _repo.getOneProductType(id));
        }


        [HttpPost]
        // [Authorize]
        public async Task<IActionResult> AddType([FromBody] ProductTypeModel type)
        {
            if (ModelState.IsValid)
            {
                await _repo.addType(type);
                return Ok();
            }

            return Ok(ModelState);
        }

        [HttpPut]
        // [Authorize]
        public async Task<IActionResult> EditType([FromBody] ProductTypeModel type)
        {
            if (ModelState.IsValid)
            {
                await _repo.editProductType(type);
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
                await _repo.deleteProductType(id);
                return Ok();
            }

            return Ok(ModelState);
        }
    }
}
