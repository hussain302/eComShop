using eComShop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Infrastructure.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        //IProductRepository Product { get; }
        //IOrderRepository Order { get; }
        void Dispose();
        Task<int> SaveAsync();
    }
}