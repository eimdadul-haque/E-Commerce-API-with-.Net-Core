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

        [HttpGet("{get-by-category}/{id}")]
        public async Task<IActionResult> GetbyCategorey([FromRoute] int id)
        {
            return Ok(await _repo.GetProByType(id));
        }


        [HttpGet("categorey")]
        public async Task<IActionResult> Categoreys()
        {
            return Ok(await _repo.GetAllType());
        }

    }
}
