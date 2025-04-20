namespace WeatherWebRecords.Models
{
    public class Catastrophe
    {
        public string Type{get;set;} = "";
        public float Severity {get;set;}
        //public int Casuality{get;set;}
        public string Cause {get;set;} ="";
    }
}