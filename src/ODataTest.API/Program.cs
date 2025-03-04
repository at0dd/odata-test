using Microsoft.EntityFrameworkCore;
using ODataTest.API.DAO;
using ODataTest.API.Models;
using ODataTest.API.Services;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAddressDAO, AddressDAO>();

builder.Services.AddDbContextPool<DataContext>(
    optionsBuilder =>
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=odata;Username=postgres;Password=postgres;Port=5434");
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
    });

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();