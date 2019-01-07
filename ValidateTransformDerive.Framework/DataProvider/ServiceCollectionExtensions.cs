using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ValidateTransformDerive.Framework.Caching;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register default cached keyed data services.
        /// </summary>
        /// <typeparam name="TKey">They type of the data key.</typeparam>
        /// <typeparam name="TValue">The value of the data.</typeparam>
        /// <typeparam name="TTransform">
        /// The type of the transform to use to transform the data into 
        /// <see cref="KeyValuePair{TKey, TValue}"/>.
        /// </typeparam>
        /// <typeparam name="TProvider">The provider of the data.</typeparam>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddCachedKeyedDataProvider<TKey, TValue, TData, TProvider>(this IServiceCollection services)
            where TData : IHaveKeyValue<TKey, TValue>
            where TProvider : class, IProvideData<TData>
        {
            // Data services
            services.AddScoped<IProvideData<TData>, TProvider>();
            services.AddCachedTypeProvider<IEnumerable<TData>>();
            services.AddScoped<IProvideCachedData<TData>, CachedDataProvider<TData>>();
            services.AddScoped<IProvideKeyValueData<TData>, CachedKeyValueDataProvider<TData, TKey, TValue>>();
            services.AddScoped<IProvideKeyValueData<TData, TKey, TValue>, CachedKeyValueDataProvider<TData, TKey, TValue>>();

            // Startup
            services.AddScoped<IHaveStartupActions, CachedDataProvider<TData>>();
        }
    }
}
