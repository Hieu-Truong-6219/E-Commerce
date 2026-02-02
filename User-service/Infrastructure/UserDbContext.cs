using Microsoft.EntityFrameworkCore;
using UserMicroService.Domain;

namespace UserMicroService.Infrastructure;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions options)
        : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "server=mssql;database=msdb;User Id=sa;Password=12345678@aA;TrustServerCertificate=True;"
        );
    }

    public DbSet<UserInfo> Users { get; set; }
}
