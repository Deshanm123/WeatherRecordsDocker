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
        [Route("GetRecord/{id}")]
        public IActionResult GetWeatherRecord(int id)
        {
            WeatherRecord? record = _context.WeatherRecords.FirstOrDefault(rec => rec.Id == id);
            if(record != null) 
                return Ok(record);
            return BadRequest("Invalid Record Request");
        }

        [HttpGet("GetRecords")]
        public IActionResult GetRecords()
        {
            List<WeatherRecord> records = _context.WeatherRecords.ToList();
            return Ok(records);
        }







    }
}



  