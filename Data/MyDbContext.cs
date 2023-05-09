using EntityFrameworkMappingAndDatabase.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkMappingAndDatabase.Data
{
    public class MyDbContext : DbContext
    {
        public readonly IConfiguration Configuration;
        public MyDbContext(DbContextOptions<MyDbContext> options, IConfiguration _configuration) : base(options)
        {
            Configuration = _configuration; 
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new PersonMapping());
            builder.ApplyConfiguration(new PassportMapping());
            builder.ApplyConfiguration(new EmployeeMapping());
            builder.ApplyConfiguration(new DepartmentMapping());
        }
    }
}
