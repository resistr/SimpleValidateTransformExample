using ValidateTransformDerive.Framework.Caching.Options.Defaults;

namespace ValidateTransformDerive.Framework.Caching.Options
{
    /// <summary>
    /// Provides option based configuration for cached types.
    /// </summary>
    public class CachedTypeOptions
    {
        /// <summary>
        /// Gets or sets the configured cache entry options.
        /// </summary>
        public CachedTypeOption[] CacheEntryOption { get; set; } = CachedTypeOptionsDefaults.CacheEntryOption;
    }
}
