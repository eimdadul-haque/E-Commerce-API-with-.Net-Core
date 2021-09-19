using Microsoft.AspNetCore.Mvc;
using OnlineShop_API.IRepository;
using System.Threading.Tasks;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public HomeController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.getAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne([FromRoute] int id)
        {
            return Ok(await _repo.getOneProduct(id));
        }


    }
}
