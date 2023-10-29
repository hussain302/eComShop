using eComShop.Domain.Aggregates;
using eComShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Domain.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
