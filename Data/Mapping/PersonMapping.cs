using EntityFrameworkMappingAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkMappingAndDatabase.Data.Mapping
{
    public class PersonMapping: IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(a => a.PersonId);
            builder.Property(a => a.Name);
            builder.HasOne(a => a.Passport).WithOne(b => b.Person).HasForeignKey<Passport>(z => z.PersonId);
        }
    }
}
