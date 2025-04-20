using System.ComponentModel.DataAnnotations.Schema;
using System.Formats.Asn1;
using WeatherWebRecords.Models;

namespace WeatherWebRecords.Models
{
    public class WeatherRecord
    {
        public int Id{get;set;}
        public DateOnly Day{get;set;}
        public string City {get;set;} ="";
        public string Country{get;set;} ="";
        public float Temperature{get;set;} 
        public int Humidity{get;set;}
        public float WindSpeed {get;set;}
        
        // [NotMapped]
        // public Catastrophe Catastrophe {get;set;}
    }

}