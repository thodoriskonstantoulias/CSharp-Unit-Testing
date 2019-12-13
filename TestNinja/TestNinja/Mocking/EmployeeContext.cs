using Microsoft.EntityFrameworkCore;

namespace TestNinja.Mocking
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}