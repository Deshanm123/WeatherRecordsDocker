using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using WeatherRecords.Data;
using WeatherWebRecords.Models;

namespace WeatherWebRecords.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherRecordController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public WeatherRecordController(ApplicationDbContext  context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/GetWeatherRecord/{id}")]
        public IActionResult GetWeatherRecord(int id)
        {
            WeatherRecord? record = _context.WeatherRecords.ToList().Find(rec => rec.Id==id);
            if(record != null) 
                return Ok("Working");
            return BadRequest(id);
        }

        [HttpGet]
        [Route("/GetWeatherRecords")]
        public IActionResult GetWeatherRecords()
        {
            List<WeatherRecord> records = _context.WeatherRecords.ToList();
            return Ok(records);
        }







    }
}



  