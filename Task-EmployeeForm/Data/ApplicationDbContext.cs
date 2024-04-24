using Microsoft.EntityFrameworkCore;
using Task_EmployeeForm.Models;

namespace Task_EmployeeForm.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

    }
}
