using Microsoft.Extensions.DependencyInjection;
using ValidateTransformDerive.Framework.Caching.Options;

namespace ValidateTransformDerive.Framework.Caching
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register caching services. 
        /// 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddCachedTypeProvider<T>(this IServiceCollection services)
        {
            services.AddSingleton<ICachedTypeOptionsProvider, CachedTypeOptionsProvider>();
            services.AddSingleton<ICachedTypeProvider<T>, CachedTypeProvider<T>>();
        }
    }
}
