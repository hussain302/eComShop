using eComShop.Domain.Entities;
using eComShop.Domain.Repositories;
using eComShop.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eComShop.Infrastructure.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SqlDbContext context): base(context)
        {
        }
    }
}