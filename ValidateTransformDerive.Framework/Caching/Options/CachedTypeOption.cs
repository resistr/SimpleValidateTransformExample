using Microsoft.Extensions.Caching.Memory;
using ValidateTransformDerive.Framework.Caching.Options.Defaults;

namespace ValidateTransformDerive.Framework.Caching.Options
{
    /// <summary>
    /// Provides option based configuration for a cached type.
    /// </summary>
    public class CachedTypeOption
    {
        /// <summary>
        /// Gets or sets the type full name of the data these cache entry options applies to. 
        /// </summary>
        public string TypeName { get; set; } = CachedTypeOptionDefaults.TypeName;

        /// <summary>
        /// Gets or sets an absolute expiration date for the cache entry.
        /// </summary>
        public MemoryCacheEntryOptions MemoryCacheEntryOptions { get; set; } = CachedTypeOptionDefaults.MemoryCacheEntryOptions;
    }
}
