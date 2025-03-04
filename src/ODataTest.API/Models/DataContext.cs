using Microsoft.EntityFrameworkCore;

namespace ODataTest.API.Models;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
}