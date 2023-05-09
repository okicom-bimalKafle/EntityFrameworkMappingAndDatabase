using EntityFrameworkMappingAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkMappingAndDatabase.Data.Mapping
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(a => a.EmployeeId);
            builder.Property(a => a.Name);

            builder.HasOne(a=>a.Department).WithMany(a => a.Employees).HasForeignKey(a => a.DepartmentId);
        }
    }
}
