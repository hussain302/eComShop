using eComShop.Domain.Entities;
using eComShop.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace eComShop.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tblProducts");
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Id)
                   .HasConversion(productId => productId.value, value => new ProductId(value));

            builder.Property(p => p.Title)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.StockQuantity);

            builder.Property(p => p.Manufacturer)
                   .HasMaxLength(255);

            builder.Property(p => p.IsFeatured);

            builder.Property(p => p.IsDeleted);

            builder.OwnsOne(
                p => p.Price,
                money =>
                {
                    money.Property(m => m.Amount)
                         .HasColumnName("Amount");

                    money.Property(m => m.Currency)
                         .HasColumnName("Currency");
                });

            builder.HasOne(p => p.Category)
                    .WithMany()
                    .HasForeignKey(p => new { p.CategoryId });

            builder.Property(c => c.CategoryId)
                .HasConversion(categoryId => categoryId.value, value => new CategoryId(value));

        }
    }
}