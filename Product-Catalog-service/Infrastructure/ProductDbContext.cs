using Microsoft.EntityFrameworkCore;
using ProductCatalogMicroService.Domain;

namespace ProductCatalogMicroService.Infrastructure;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=mssql;database=msdb;User Id=sa;Password=12345678@aA;TrustServerCertificate=True;"
        );
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Company> Companies { get; set; }
}
