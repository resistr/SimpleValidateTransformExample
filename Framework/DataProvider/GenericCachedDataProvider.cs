using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    /// <summary>
    /// A generic implementation of <see cref="IProvideCachedData{T}"/>. 
    /// </summary>
    /// <typeparam name="T">The type of data to cache and provide.</typeparam>
    public class GenericCachedDataProvider<T> : CachedProviderBase, IProvideCachedData<T>, IHaveStartupActions
    {        
        protected readonly IProvideData<T> DataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCachedDataProvider{T}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the data.</param>
        /// <param name="memoryCache">The memory cache service to use.</param>
        public GenericCachedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache)
            : this(dataProvider, memoryCache, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCachedDataProvider{T}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the data.</param>
        /// <param name="memoryCache">The memory cache service to use.</param>
        /// <param name="memoryCacheEntryOptions">The options to provide the memory cache service.</param>
        public GenericCachedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
            : base(memoryCache, memoryCacheEntryOptions)
            => DataProvider = dataProvider;

        /// <summary>
        /// Gets all items from the cache. Populates the cache from the provider if not already populated.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The collection of data from the cache.</returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await GetOrCreateAsync(async (token) => await DataProvider.GetAllAsync(token), cancellationToken);

        /// <summary>
        /// Populates the cache from the provider.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>A task representing the work being done at startup.</returns>
        public virtual async Task Startup(CancellationToken cancellationToken = default)
            => await GetAllAsync(cancellationToken);
    }
}
