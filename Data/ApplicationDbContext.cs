using Microsoft.EntityFrameworkCore;
using WeatherWebRecords.Models;

namespace WeatherRecords.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<WeatherRecord> WeatherRecords { get; set; }


    public static async Task ConfigureDatabase(ApplicationDbContext? context)
    {
        try
        {
            if (context != null)
            {
                await context.Database.EnsureCreatedAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message.ToString());
        }
    }
    public static async Task SeedingDatabase(ApplicationDbContext? context)
    {
        try
        {
            if (context !=null && !context.WeatherRecords.Any())
            {
                List<WeatherRecord> records = new List<WeatherRecord>()
                {
                    //EventType = "Earthquake"
                    new WeatherRecord
                    {
                       // Id = 1,
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
                       // Id = 2,
                        Day = new DateOnly(2025, 4, 18),
                        City = "San Francisco",
                        Country = "USA",
                        Temperature = 17.8f,
                        Humidity = 78,
                        WindSpeed = 8.7f
                    }
                };
                context.AddRange(records);
                context.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }


}