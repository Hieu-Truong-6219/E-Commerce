using Microsoft.EntityFrameworkCore;
using ShoppingCartMicroService.Domain;

namespace ShoppingCartMicroService.Infrastructure;

public class CartDbContext : DbContext
{
    public CartDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=mssql;database=msdb;User Id=sa;Password=12345678@aA;TrustServerCertificate=True;"
        );
    }

    public DbSet<Cart> Carts { get; set; }
}
