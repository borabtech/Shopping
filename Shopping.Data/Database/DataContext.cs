using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopping.Data.Entity;

namespace Shopping.Data.Database;

public class DataContext : DbContext
{
    readonly IConfiguration _configuration;
    public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration): base(options)
    {
        _configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("ShoppingConnectionString"));
    }

    public DbSet<Item> Items { get; set; }
}