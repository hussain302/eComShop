using eComShop.Domain.Repositories;
using eComShop.Persistence.Contexts;

namespace eComShop.Infrastructure.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SqlDbContext _context;

        public UnitOfWork(SqlDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public ICategoryRepository Category { get; private init; }
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();      
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) _context.Dispose();            
        }
    }
}
