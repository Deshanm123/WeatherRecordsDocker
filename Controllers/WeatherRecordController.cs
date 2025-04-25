using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherRecords.Data;
using WeatherWebRecords.Models;

namespace WeatherWebRecords.Contollers
{ 
    [ApiController]
    [Route("[controller]")]
    public class WeatherRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WeatherRecordController(ApplicationDbContext  context)
        {
            _context = context;
        }

        [HttpGet("GetWeatherRecord")]
        [Route("/WeatherRecord/GetWeatherRecord/{id}")]
        public IActionResult GetWeatherRecord(int id)
        {
            WeatherRecord? record = _context.WeatherRecords.ToList().Find(rec => rec.Id==id);
            if(record != null) 
                return Ok("Working");
            return BadRequest(id);
        }

        [HttpGet("WeatherRecords")]
        [Route("/WeatherRecord/GetWeatherRecords")]
        public IActionResult GetWeatherRecords()
        {
            List<WeatherRecord> records = _context.WeatherRecords.ToList();
            return Ok(records);
        }







    }
}



  