using EntityFrameworkMappingAndDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityFrameworkMappingAndDatabase.Data.Mapping
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .UsingEntity(j => j.ToTable("ProductCategories"));
        }
    }
}
