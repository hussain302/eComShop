using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eComShop.Domain.Entities;
using eComShop.Domain.ValueObjects;

namespace eComShop.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("tblCategories");
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id)
                   .HasConversion(categoryId => categoryId.value, value => new CategoryId(value));

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(c => c.Description)
                   .HasMaxLength(1000);

        }
    }
}
