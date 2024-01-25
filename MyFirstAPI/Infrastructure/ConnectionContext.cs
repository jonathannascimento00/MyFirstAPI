using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Model;

namespace MyFirstAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=server;" +
                "Port=5432; Database=thedatabasename;" +
                "User Id = youruser;" +
                "Password=youruserpassword"
            );
    }
}
