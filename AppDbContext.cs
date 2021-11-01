using Microsoft.EntityFrameworkCore;

namespace MvcApp2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Mindaugas" },
                new Employee() { Id = 2, Name = "Petras" }
            );
        }
    }
}