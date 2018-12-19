using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    public abstract class CachedProviderBase<T> where T : class
    {
        protected readonly MemoryCacheEntryOptions DefaultMemoryCacheEntryOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.MaxValue };
        protected readonly IMemoryCache MemoryCache;
        protected readonly MemoryCacheEntryOptions MemoryCacheEntryOptions;

        protected CachedProviderBase(IMemoryCache memoryCache) : this(memoryCache, null) { }
        
        protected CachedProviderBase(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
        {
            MemoryCache = memoryCache;
            MemoryCacheEntryOptions = memoryCacheEntryOptions ?? DefaultMemoryCacheEntryOptions;
        }

        protected virtual async Task<T> GetOrCreateAsync(
            Func<CancellationToken, Task<T>> func,
            CancellationToken cancellationToken = default)
            => await MemoryCache.GetOrCreateAsync(CacheKey<T>.Instance, async (cacheEntry) =>
            {
                var cacheValue = cacheEntry.Value as T;
                if (cacheValue == null)
                {
                    cacheValue = await func(cancellationToken);
                    cacheEntry.SetOptions(MemoryCacheEntryOptions);
                    cacheEntry.SetValue(cacheValue);
                }
                return cacheValue;
            });
    }
}
