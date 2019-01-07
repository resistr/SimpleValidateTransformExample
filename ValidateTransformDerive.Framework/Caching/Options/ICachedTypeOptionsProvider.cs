using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Caching.Options
{
    /// <summary>
    /// Provides <see cref="CachedTypeOption"/>.
    /// </summary>
    public interface ICachedTypeOptionsProvider : IProvideData<CachedTypeOption>
    {

        /// <summary>
        /// Gets the <see cref="CachedTypeOption"/> for the provided type name. 
        /// </summary>
        /// <param name="typeName">The name of the type to get the <see cref="CachedTypeOption"/> for.</param>
        /// <returns>The matching <see cref="CachedTypeOption"/> for the provided type name or a default instance of the options.</returns>
        CachedTypeOption GetCacheEntryOption(string typeName);
    }
}
    