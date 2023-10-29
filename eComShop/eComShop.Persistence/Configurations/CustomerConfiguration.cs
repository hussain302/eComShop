using eComShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eComShop.Domain.ValueObjects;

namespace eComShop.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("tblCustomers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasConversion(customerId => customerId.value, value => new CustomerId(value));

            builder.Property(c => c.FirstName)
                   .HasMaxLength(255);

            builder.Property(c => c.LastName)
                   .HasMaxLength(255);

            builder.Property(c => c.Email)
                   .HasMaxLength(255);

            builder.Property(c => c.Phone)
                   .HasMaxLength(20);

            builder.OwnsOne(
                c => c.ShippingAddress,
                sa =>
                {
                    sa.Property(a => a.Country).HasColumnName("Country").HasMaxLength(100);
                    sa.Property(a => a.State).HasColumnName("State").HasMaxLength(100);
                    sa.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
                    sa.Property(a => a.Street).HasColumnName("Street").HasMaxLength(255);
                    sa.Property(a => a.PostalCode).HasColumnName("PostalCode").HasMaxLength(20);
                });
        }
    }
}