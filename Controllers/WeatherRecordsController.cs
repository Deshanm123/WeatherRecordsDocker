using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using WeatherWebRecords.Models;

namespace WeatherWebRecords.Contollers
{ 
    [ApiController]
    [Route("[controller]")]
    public class WeatherRecordsController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherRecord")]
        [Route("/weatherRecords/getWeatherRecord/{id}")]
        public IActionResult GetWeatherRecord(int id)
        {

            return Ok("Working");
        }

        [HttpGet(Name = "GetAllWeatherRecords")]
        [Route("/weatherRecords/getAllWeatherRecords")]
        public IActionResult GetAllWeatherRecords()
        {
             // Create sample records
            var records = new List<WeatherRecord>()
            {
                    //EventType = "Earthquake"
                    new WeatherRecord
                    {
                        Id = 1,
                        Day = new DateOnly(2025, 4, 19),
                        City = "Tokyo",
                        Country = "Japan",
                        Temperature = 23.5f,
                        Humidity = 65,
                        WindSpeed = 12.3f
                    },
                    // EventType = "Flood"
                    new WeatherRecord
                    {
                        Id = 2,
                        Day = new DateOnly(2025, 4, 18),
                        City = "San Francisco",
                        Country = "USA",
                        Temperature = 17.8f,
                        Humidity = 78,
                        WindSpeed = 8.7f
                    }
            };
            return Ok(records);
        }







    }
}



  