using Microsoft.EntityFrameworkCore;

namespace Employee.Models
{
    public class EmployeeContext: DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employe> Employees { get; set; }

      

    }
}
