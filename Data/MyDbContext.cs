using EntityFrameworkMappingAndDatabase.Data.Mapping;
using EntityFrameworkMappingAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace EntityFrameworkMappingAndDatabase.Data
{
    public class MyDbContext : DbContext
    {
        public readonly IConfiguration Configuration;
        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration _configuration) : base(options)
        {
            Configuration = _configuration;
            try
            {
                var DatabaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if(DatabaseCreator != null )
                {
                    if (!DatabaseCreator.CanConnect()) DatabaseCreator.Create();
                    if (!DatabaseCreator.HasTables()) DatabaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonMapping());
            builder.ApplyConfiguration(new PassportMapping());
            builder.ApplyConfiguration(new EmployeeMapping());
            builder.ApplyConfiguration(new DepartmentMapping());
            builder.ApplyConfiguration(new ProductMapping());
            builder.ApplyConfiguration (new CategoryMapping());
        }
    }
}
