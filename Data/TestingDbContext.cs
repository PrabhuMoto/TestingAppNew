using Microsoft.EntityFrameworkCore;
using TestingApp.Configuration;
using TestingApp.Models;

namespace TestingApp.Data;
public class TestingDbContext : DbContext
{
    public TestingDbContext(DbContextOptions<TestingDbContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}