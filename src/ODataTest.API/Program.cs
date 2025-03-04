using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Microsoft.OData.ModelBuilder;
using ODataTest.API.DAO;
using ODataTest.API.Models;
using ODataTest.API.Services;
using Scalar.AspNetCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

ODataConventionModelBuilder modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Order>("orders");
modelBuilder.EntitySet<Customer>("customers");

builder.Services
    .AddControllers()
    .AddOData(
        options => options
            .Select()
            .Filter()
            .OrderBy()
            .Expand()
            .Count()
            .SetMaxTop(null)
            .AddRouteComponents(modelBuilder.GetEdmModel()))
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
        });

builder.Services.AddOpenApi();

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<ICustomerDAO, CustomerDAO>();
builder.Services.AddScoped<IOrderDAO, OrderDAO>();

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