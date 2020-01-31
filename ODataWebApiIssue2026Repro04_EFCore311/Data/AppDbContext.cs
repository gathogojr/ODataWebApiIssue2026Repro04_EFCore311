using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ODataWebApiIssue2026Repro04_EFCore311.Models;

namespace ODataWebApiIssue2026Repro04_EFCore311.DataSources
{
    public class AppDbContext : DbContext
    {
        private static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder => {
            builder.AddConsole();
        });

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLoggerFactory(_loggerFactory)
                    .UseSqlServer(@"Data Source = (LocalDb)\MSSQLLocalDB; Integrated Security = True; Persist Security Info = True; Database = Repro04EmpDb");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seed Data
            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "Marketing" }
            );

            builder.Entity<Employer>().HasData(
                new Employer { Id = 1, Name = "Gabriela Barron" },
                new Employer { Id = 2, Name = "Gavyn Navarro" }
            );

            builder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Janiya Rich", EmployerId = 1, DepartmentId = 1 },
                new Employee { Id = 2, Name = "Lailah Morgan", EmployerId = 1, DepartmentId = 2 },
                new Employee { Id = 3, Name = "Aden Salas", EmployerId = 1, DepartmentId = 2 },
                new Employee { Id = 4, Name = "Clark Knight", EmployerId = 1, DepartmentId = 1 },
                new Employee { Id = 5, Name = "Miya Hardin", EmployerId = 1, DepartmentId = 1 },
                new Employee { Id = 6, Name = "Johnny Stuart", EmployerId = 2, DepartmentId = 2 },
                new Employee { Id = 7, Name = "Cloe Nolan", EmployerId = 2, DepartmentId = 1 },
                new Employee { Id = 8, Name = "Diana Vargas", EmployerId = 2, DepartmentId = 1 },
                new Employee { Id = 9, Name = "Leroy Byrd", EmployerId = 2, DepartmentId = 2 }
            );
        }
    }
}
