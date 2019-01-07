using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Caching.Options;

namespace ValidateTransformDerive.Framework.Caching
{
    /// <summary>
    /// A class providing common functionality for interacting with the types stored in 
    /// <see cref="Microsoft.Extensions.Caching.Memory.IMemoryCache"/>.
    /// </summary>
    /// <typeparam name="T">The type of item(s) to get or add to the cache.</typeparam>
    public class CachedTypeProvider<T> : ICachedTypeProvider<T>
    {
        protected readonly IMemoryCache MemoryCache;
        protected readonly ICachedTypeOptionsProvider CacheEntryOptionsProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedTypeProvider{T}"/> class.
        /// </summary>
        /// <param name="memoryCache">The memory cache service to use.</param>
        /// <param name="cacheEntryOptionsProvider">The options to provide the memory cache entries.</param>
        public CachedTypeProvider(IMemoryCache memoryCache, ICachedTypeOptionsProvider cacheEntryOptionsProvider)
        {
            MemoryCache = memoryCache;
            CacheEntryOptionsProvider = cacheEntryOptionsProvider;
        }

        /// <summary>
        /// Gets the requested type of item(s) from the memory cache. If unavailable;
        /// Runs the provided function to obtain the items and caches them.
        /// </summary>
        /// <param name="func">The delegate to call to retrieve the data if not available in the cache.</param>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The item(s) from the cache.</returns>
        public virtual async Task<T> GetOrCreateAsync(
            Func<CancellationToken, Task<T>> func,
            CancellationToken cancellationToken = default)
            => await MemoryCache.GetOrCreateAsync(CachedTypeKey<T>.Instance, async (cacheEntry) =>
            {
                cacheEntry.SetOptions(CacheEntryOptionsProvider.GetCacheEntryOption<T>().MemoryCacheEntryOptions);
                return await func(cancellationToken);
            });
    }
}
