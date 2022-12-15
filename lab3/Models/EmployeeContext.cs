using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace lab3.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
    }
}