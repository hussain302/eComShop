using eComShop.Domain.Repositories;
using eComShop.Infrastructure.DataAccess.Repositories;
using eComShop.Infrastructure.DataAccess.UnitOfWork;
using eComShop.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace eComShop.Infrastructure.DependencyRegistrar
{
    public class DependencyRegistrer
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<SqlDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}