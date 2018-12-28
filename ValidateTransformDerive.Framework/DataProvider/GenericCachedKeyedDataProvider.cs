using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// A generic implementation of <see cref="IProvideKeyedData{TKey, TValue}"/> built on <see cref="GenericCachedDataProvider{T}"/>
    /// that provides cached keyed data.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class GenericCachedKeyedDataProvider<TKey, TValue>      
        : GenericCachedDataProvider<KeyValuePair<TKey, TValue>>, IProvideKeyedData<TKey, TValue>
        where TValue : IProvideValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCachedKeyedDataProvider{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the keyed data.</param>
        /// <param name="memoryCache">The memory cache service to use.</param>
        public GenericCachedKeyedDataProvider(IProvideData<KeyValuePair<TKey, TValue>> dataProvider, IMemoryCache memoryCache)
            : this(dataProvider, memoryCache, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCachedKeyedDataProvider{TKey, TValue}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the keyed data.</param>
        /// <param name="memoryCache">The memory cache service to use.</param>
        /// <param name="memoryCacheEntryOptions">The options to provide the memory cache service.</param>
        public GenericCachedKeyedDataProvider(IProvideData<KeyValuePair<TKey, TValue>> dataProvider, IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
            : base(dataProvider, memoryCache, memoryCacheEntryOptions) { }

        /// <summary>
        /// Gets all items from the cache. Populates the cache from the provider if not already populated.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The collection of data from the cache.</returns>
        public override async Task<IEnumerable<KeyValuePair<TKey, TValue>>> GetAllAsync(CancellationToken cancellationToken = default)
            => (await GetTypedReadOnlyDictionaryAsync(cancellationToken));

        /// <summary>
        /// Gets all items from the cache. Populates the cache from the provider if not already populated.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The untyped dictonary of data from the cache.</returns>
        public async Task<IReadOnlyDictionary<object, IProvideValue>> GetReadOnlyDictionaryAsync(CancellationToken cancellationToken = default)
            => (await GetTypedReadOnlyDictionaryAsync(cancellationToken)).ToValueReadOnlyDictionary();

        /// <summary>
        /// Gets all items from the cache. Populates the cache from the provider if not already populated.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The typed dictonary of data from the cache.</returns>
        public async Task<IReadOnlyDictionary<TKey, TValue>> GetTypedReadOnlyDictionaryAsync(CancellationToken cancellationToken = default)
            => await GetOrCreateAsync(async (token) => (await DataProvider.GetAllAsync(token)).ToTypedReadOnlyDictionary(), cancellationToken);
    }
}
