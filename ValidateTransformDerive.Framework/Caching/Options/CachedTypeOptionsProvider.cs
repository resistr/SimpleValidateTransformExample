using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Caching.Options
{
    /// <summary>
    /// Provides <see cref="CachedTypeOption"/>.
    /// </summary>
    public class CachedTypeOptionsProvider : ICachedTypeOptionsProvider
    {
        protected readonly CachedTypeOptions CacheEntryOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachedTypeOptionsProvider"/> class.
        /// </summary>
        /// <param name="cacheEntryOptions">The <see cref="IOptionsMonitor{TOptions}"/> for the cache entry options.</param>
        public CachedTypeOptionsProvider(IOptionsMonitor<CachedTypeOptions> cacheEntryOptions)
            => CacheEntryOptions = cacheEntryOptions.CurrentValue;

        public Task<IEnumerable<CachedTypeOption>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(CacheEntryOptions.CacheEntryOption as IEnumerable<CachedTypeOption>);

        /// <summary>
        /// Gets the <see cref="CachedTypeOption"/> for the provided type name. 
        /// </summary>
        /// <param name="typeName">The name of the type to get the <see cref="CachedTypeOption"/> for.</param>
        /// <returns>The matching <see cref="CachedTypeOption"/> for the provided type name or a default instance of the options.</returns>
        public CachedTypeOption GetCacheEntryOption(string typeName)
            => CacheEntryOptions?.CacheEntryOption.FirstOrDefault(option => option.TypeName == typeName) 
            ?? new CachedTypeOption();
    }
}
    