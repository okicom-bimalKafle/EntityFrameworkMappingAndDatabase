using EntityFrameworkMappingAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace EntityFrameworkMappingAndDatabase.Data.Mapping
{
    public class PassportMapping:IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> builder)
        {
            builder.HasKey(a=>a.PassportId);
            builder.Property(a => a.Number);
            builder.HasOne(a => a.Person).WithOne(b => b.Passport).HasForeignKey<Passport>(z => z.PersonId);
        }
    }
}
