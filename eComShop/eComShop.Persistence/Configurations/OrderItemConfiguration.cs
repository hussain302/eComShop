using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using eComShop.Domain.Entities;
using eComShop.Domain.ValueObjects;

namespace eComShop.Persistence.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("tblOrderItems");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Quantity);

            builder.OwnsOne(
                p => p.TotalPrice,
                money =>
                {
                    money.Property(m => m.Amount)
                         .HasColumnName("TotalAmount");

                    money.Property(m => m.Currency)
                         .HasColumnName("Currency");
                });

            builder.HasOne(p => p.Product)
                   .WithOne()
                   .HasForeignKey<OrderItem>(p => p.ProductId);

            builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(oi => oi.OrderId)
               .IsRequired();

            builder.Property(p => p.OrderId)
                   .HasConversion(orderId => orderId.value, value => new OrderId(value));

            builder.Property(p => p.Id)
                   .HasConversion(orderItemId => orderItemId.value, value => new OrderItemId(value));

            builder.Property(p => p.ProductId)
                .HasConversion(productId => productId.value, value => new ProductId(value));
        }
    }
}
