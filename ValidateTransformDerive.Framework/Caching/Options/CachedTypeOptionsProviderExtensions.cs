using System;

namespace ValidateTransformDerive.Framework.Caching.Options
{
    public static class CachedTypeOptionsProviderExtensions
    {
        public static CachedTypeOption GetCacheEntryOption<T>(this ICachedTypeOptionsProvider cacheEntryOptionsProvider)
            => cacheEntryOptionsProvider.GetCacheEntryOption(typeof(T));

        public static CachedTypeOption GetCacheEntryOption(this ICachedTypeOptionsProvider cacheEntryOptionsProvider, Type type)
            => cacheEntryOptionsProvider.GetCacheEntryOption(type.FullName);
    }
}
    