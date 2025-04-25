using Microsoft.AspNetCore.Mvc;

namespace WeatherWebRecords.Contollers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/Home/Index")]
        public IActionResult Index()
        {
            return Ok("Web is Running");
        }

    }
    
}