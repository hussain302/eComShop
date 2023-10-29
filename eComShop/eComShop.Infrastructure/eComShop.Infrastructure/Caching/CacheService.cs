using Microsoft.Extensions.Caching.Memory;

namespace eComShop.Infrastructure.Caching
{
    public class CacheService
    {
        private readonly IMemoryCache _memoryCache;

        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string GetFromCacheOrDatabase(string key)
        {
            if (_memoryCache.TryGetValue(key, out string cachedValue))
            {
                return cachedValue;
            }

            //string databaseValue = YourDatabaseRepository.GetDataByKey(key); // Replace with your database access logic
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10)
            };

            // _memoryCache.Set(key, databaseValue, cacheEntryOptions);

            return null;
        }
    }
}
