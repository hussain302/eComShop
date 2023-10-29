using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eComShop.Domain.ValueObjects;
using eComShop.Domain.Aggregates;

namespace eComShop.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("tblOrders");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasConversion(orderId => orderId.value, value => new OrderId(value));

            builder.Property(p => p.OrderDate);
            builder.Property(p => p.OrderStatus);
            builder.Property(p => p.PaymentMethod);
            builder.Property(p => p.ExpectedDeliveryDate);
            builder.Property(p => p.OrderNotes);
            builder.Property(p => p.TrackingNumber);
            builder.Property(p => p.IsPaid);
            builder.HasMany(o => o.OrderItems)
                   .WithOne(o => o.Order)
                   .HasForeignKey(o => o.OrderId);

            builder.OwnsOne(
                p => p.TotalBill,
                money =>
                {
                    money.Property(m => m.Amount)
                         .HasColumnName("TotalBilledAmount");

                    money.Property(m => m.Currency)
                         .HasColumnName("Currency");
                });

            builder.OwnsOne(
                o => o.ShippingAddress,
                sa =>
                {
                    sa.Property(a => a.Country).HasColumnName("Country").HasMaxLength(100);
                    sa.Property(a => a.State).HasColumnName("State").HasMaxLength(100);
                    sa.Property(a => a.City).HasColumnName("City").HasMaxLength(100);
                    sa.Property(a => a.Street).HasColumnName("Street").HasMaxLength(255);
                    sa.Property(a => a.PostalCode).HasColumnName("PostalCode").HasMaxLength(20);
                });

            builder.HasOne(p => p.Customer)
                   .WithMany()
                   .HasForeignKey(p => p.CustomerId);

            builder.Property(p => p.CustomerId)
                .HasConversion(customerId => customerId.value, value => new CustomerId(value));

        }
    }
}
