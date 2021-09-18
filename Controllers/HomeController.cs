using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnlineShop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public async Task<IActionResult> Get()
        {
            return Ok("<h1>Hello...</h1>");
        }
  
    }
}
