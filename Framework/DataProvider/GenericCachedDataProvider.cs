using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    public class GenericCachedDataProvider<T> : CachedProviderBase<IEnumerable<T>>, IProvideCachedData<T>, IHaveStartupActions where T : class
    {        
        protected readonly IProvideData<T> DataProvider;

        public GenericCachedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache)
            : this(dataProvider, memoryCache, null) { }

        public GenericCachedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
            : base(memoryCache, memoryCacheEntryOptions)
            => DataProvider = dataProvider;

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await GetOrCreateAsync(async (token) => await DataProvider.GetAllAsync(token), cancellationToken);

        public virtual async Task Startup(CancellationToken cancellationToken = default)
            => await GetAllAsync(cancellationToken);
    }
}
