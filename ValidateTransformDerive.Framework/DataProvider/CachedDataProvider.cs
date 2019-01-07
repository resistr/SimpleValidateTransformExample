using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Caching;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// An implementation of <see cref="IProvideCachedData{T}"/>. 
    /// </summary>
    /// <typeparam name="T">The type of data to cache and provide.</typeparam>
    public class CachedDataProvider<T> : IProvideCachedData<T>
    {        
        protected readonly IProvideData<T> DataProvider;
        protected readonly ICachedTypeProvider<IEnumerable<T>> CachedTypeProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedDataProvider{T}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the data.</param>
        /// <param name="cachedTypeProvider">The cache type provider to use.</param>
        public CachedDataProvider(IProvideData<T> dataProvider, ICachedTypeProvider<IEnumerable<T>> cachedTypeProvider)
        {
            DataProvider = dataProvider;
            CachedTypeProvider = cachedTypeProvider;
        }

        /// <summary>
        /// Gets all items from the cache. Populates the cache from the provider if not already populated.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The collection of data from the cache.</returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await CachedTypeProvider.GetOrCreateAsync(async (token) => await DataProvider.GetAllAsync(token), cancellationToken);

        /// <summary>
        /// Populates the cache from the provider.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>A task representing the work being done at startup.</returns>
        public virtual async Task Startup(CancellationToken cancellationToken = default)
            => await GetAllAsync(cancellationToken);
    }
}
