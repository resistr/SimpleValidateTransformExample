namespace ValidateTransformDerive.Framework.Caching
{
    /// <summary>
    /// An object used to keep cached information segrated by type in the memory cache.
    /// </summary>
    /// <typeparam name="T">The type of information being cached.</typeparam>
    public sealed class CachedTypeKey<T>
    {
        /// <summary>
        /// The instance of the cache key for the given type.
        /// </summary>
        public static object Instance { get; } = new CachedTypeKey<T>();

        /// <summary>
        /// Hidden to prevent misuse.
        /// </summary>
        private CachedTypeKey() { }
    }
}
