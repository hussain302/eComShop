using eComShop.Domain.Aggregates;
using eComShop.Domain.Entities;
using eComShop.Persistence.ConnectionStrings;
using eComShop.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
namespace eComShop.Persistence.Contexts
{
    public class SqlDbContext : DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString: ConnectionString.SqlServerConnectionString)
                          .UseLazyLoadingProxies(useLazyLoadingProxies: true);
        }
    }
}