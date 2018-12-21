using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    /// <summary>
    /// An abstract class providing common functionality for interacting with the 
    /// Memory cache.
    /// </summary>
    public abstract class CachedProviderBase
    {
        protected readonly MemoryCacheEntryOptions DefaultMemoryCacheEntryOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.MaxValue };
        protected readonly IMemoryCache MemoryCache;
        protected readonly MemoryCacheEntryOptions MemoryCacheEntryOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedProviderBase"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache service to use.</param>
        protected CachedProviderBase(IMemoryCache memoryCache) : this(memoryCache, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedProviderBase"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache service to use.</param>
        /// <param name="memoryCacheEntryOptions">The options to provide the memory cache service.</param>
        protected CachedProviderBase(IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
        {
            MemoryCache = memoryCache;
            MemoryCacheEntryOptions = memoryCacheEntryOptions ?? DefaultMemoryCacheEntryOptions;
        }

        /// <summary>
        /// Gets the requested type of items from the memory cache. If unavailable;
        /// Runs the provided function to obtain the items and caches them.
        /// </summary>
        /// <typeparam name="T">The type of item(s) to get or add to the cache.</typeparam>
        /// <param name="func">The delegate to call to retrieve the data if not available in the cache.</param>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The collection of data from the cache.</returns>
        protected virtual async Task<T> GetOrCreateAsync<T>(
            Func<CancellationToken, Task<T>> func,
            CancellationToken cancellationToken = default) where T : class
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
