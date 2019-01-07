using Microsoft.Extensions.Caching.Memory;
using System;

namespace ValidateTransformDerive.Framework.Caching.Options.Defaults
{
    /// <summary>
    /// Provides defaults for <see cref="CachedTypeOption"/>
    /// </summary>
    public static class CachedTypeOptionDefaults
    {
        /// <summary>
        /// Gets the default system type string of the data the options applies to. 
        /// </summary>
        public static string TypeName { get => null; }

        /// <summary>
        /// Gets the default <see cref="MemoryCacheEntryOptions"/> for the cache type.
        /// </summary>
        public static MemoryCacheEntryOptions MemoryCacheEntryOptions
        { get => new MemoryCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.MaxValue }; }
    }
}
