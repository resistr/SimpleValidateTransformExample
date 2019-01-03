using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ValidateTransformDerive.Framework.Transformation;

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
        public static void AddCachedKeyedDataProvider<TKey, TValue, TData, TProvider, TTransform>(this IServiceCollection services)
            where TData : IProvideKey<TKey>, IProvideValue<TValue>
            where TProvider : class, IProvideData<TData>
            where TTransform : class, ITransform<TData, KeyValuePair<TKey, TData>>
        {
            // Data services
            services.AddScoped<IProvideData<TData>, TProvider>();
            services.AddTransformationService<TData, KeyValuePair<TKey, TData>, TTransform>();
            services.AddScoped<IProvideData<KeyValuePair<TKey, TData>>, GenericTransformDataProvider<TData, KeyValuePair<TKey, TData>>>();
            services.AddScoped<IProvideKeyedData<TData>, GenericCachedKeyedDataProvider<TData, TKey, TValue>>();
            services.AddScoped<IProvideKeyedData<TData, TKey, TValue>, GenericCachedKeyedDataProvider<TData, TKey, TValue>>();

            // Startup
            services.AddScoped<IHaveStartupActions, GenericCachedKeyedDataProvider<TData, TKey, TValue>>();
        }
    }
}
