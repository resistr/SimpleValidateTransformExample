﻿namespace Framework.DataProvider
{
    /// <summary>
    /// An object used to keep cached information segrated in the memory cache.
    /// </summary>
    /// <typeparam name="T">The type of information being cached.</typeparam>
    public sealed class CacheKey<T>
    {
        /// <summary>
        /// The instance of the cache key for the given type.
        /// </summary>
        public static object Instance { get; } = new CacheKey<T>();

        /// <summary>
        /// Hidden to prevent misuse.
        /// </summary>
        private CacheKey() { }
    }
}
