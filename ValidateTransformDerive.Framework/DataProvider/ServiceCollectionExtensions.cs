using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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
        public static void AddCachedKeyedDataProvider<TKey, TValue, TProvider>(this IServiceCollection services)
            where TValue : IProvideValue
            where TProvider : class, IProvideData<TValue>
        {
            // Data services
            services.AddScoped<IProvideData<TValue>, TProvider>();
            services.AddScoped<IProvideData<KeyValuePair<TKey, TValue>>, GenericTransformDataProvider<TValue, KeyValuePair<TKey, TValue>>>();
            services.AddScoped<IProvideKeyedData<TKey, TValue>, GenericCachedKeyedDataProvider<TKey, TValue>>();

            // Startup
            services.AddScoped<IHaveStartupActions, GenericCachedKeyedDataProvider<TKey, TValue>>();
        }
    }
}
