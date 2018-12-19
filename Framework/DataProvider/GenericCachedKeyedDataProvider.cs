using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    public class GenericCachedKeyedDataProvider<T> : GenericCachedDataProvider<T>, IProvideKeyedData<T>, IProvideKeyedData where T : class, IProvideKeyedValue
    {        
        public GenericCachedKeyedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache)
            : this(dataProvider, memoryCache, null) { }

        public GenericCachedKeyedDataProvider(IProvideData<T> dataProvider, IMemoryCache memoryCache, MemoryCacheEntryOptions memoryCacheEntryOptions)
            : base(dataProvider, memoryCache, memoryCacheEntryOptions) { }

        public async Task<IReadOnlyDictionary<object, object>> ToReadOnlyDictionaryAsync(CancellationToken cancellationToken = default)
            => (await GetAllAsync(cancellationToken)).ToReadOnlyDictionary();
    }
}
