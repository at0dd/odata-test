using Microsoft.EntityFrameworkCore;

namespace ODataTest.API.Models;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Address> Addresses { get; set; }
}