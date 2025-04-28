using Microsoft.AspNetCore.Mvc;

namespace WeatherWebRecords.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Ok("Web is Running");
        }

    }
    
}