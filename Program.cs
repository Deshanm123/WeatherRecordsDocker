using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherRecords.Data;
using WeatherWebRecords.Controllers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://akagi.ms/aspnet/openapi

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();
using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    ApplicationDbContext? context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
    await ApplicationDbContext.ConfigureDatabase(context);
    await ApplicationDbContext.SeedingDatabase(context);
}

// Configure the HTTP request pipeline.
app.UseRouting();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

app.Run();
