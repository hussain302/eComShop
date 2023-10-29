using eComShop.Domain.Repositories;
using eComShop.Infrastructure.DataAccess.Repositories;
using eComShop.Persistence.Contexts;

namespace eComShop.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository Category { get; private set; }
        //public IProductRepository Product { get; private set; }
        
       // public IOrderRepository Order { get; private set; }

        private readonly SqlDbContext _context;
        public UnitOfWork(SqlDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            //Product = new ProductRepository(context);           
            //Order = new OrderRepository(context);
        }

        public async Task<int> Save()
        {
            int response = await _context.SaveChangesAsync();
            return response;
        }
    }
}