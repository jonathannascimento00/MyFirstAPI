using Microsoft.EntityFrameworkCore;
using MyFirstAPI.Domain.Model;

namespace MyFirstAPI.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        public DbSet<Employee> Employess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432; Database=database;" +
                "User Id = user;" +
				"Password=password"
			);
    }
}
