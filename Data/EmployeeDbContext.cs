using Microsoft.EntityFrameworkCore;
using Web_API_and_EFcore.Models;

namespace Web_API_and_EFcore.Data;

public class EmployeeDbContext : DbContext
{
    public EmployeeDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Employee> MyProperty { get; set; }
}