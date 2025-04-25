using Microsoft.EntityFrameworkCore;
using WeatherRecords.Data;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=WeatherRecord}/{action=GetWeatherRecords}"
);
//app.UseHttpsRedirection();
// app.MapControllerRoute(
//         name:"default",
//         pattern:"{controller=WeatherRecord}/{action=GetWeatherRecords}"
// );

app.MapControllers();
app.Run();
