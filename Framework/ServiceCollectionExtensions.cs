using Framework.DataProvider;
using Framework.Derivation;
using Framework.Transformation;
using Framework.Validation;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Framework
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register default framework services. 
        /// 
        ///  - IDerivationService
        ///  - IValidationService
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddFrameworkServices(this IServiceCollection services)
        {
            // add derivation
            services.AddScoped<IDerivationService, DerivationService>();

            // add validation
            services.AddScoped<IValidationService, ValidationService>();
        }

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
        public static void AddCachedKeyedDataProvider<TKey, TValue, TTransform, TProvider>(this IServiceCollection services)
            where TValue : IProvideValue
            where TTransform : class, ITransform<TValue, KeyValuePair<TKey, TValue>>
            where TProvider : class, IProvideData<TValue>
        {
            // Data transform
            services.AddTransformationService<TValue, KeyValuePair<TKey, TValue>, TTransform>();

            // Data services
            services.AddScoped<IProvideData<TValue>, TProvider>();
            services.AddScoped<IProvideData<KeyValuePair<TKey, TValue>>, GenericTransformDataProvider<TValue, KeyValuePair<TKey, TValue>>>();
            services.AddScoped<IProvideKeyedData<TKey, TValue>, GenericCachedKeyedDataProvider<TKey, TValue>>();

            // Startup
            services.AddScoped<IHaveStartupActions, GenericCachedKeyedDataProvider<TKey, TValue>>();
        }

        /// <summary>
        /// Register default transformation services.
        /// </summary>
        /// <typeparam name="TSource">The source type of the transformation.</typeparam>
        /// <typeparam name="TDest">The dest type of the transformation.</typeparam>
        /// <typeparam name="TTransform">The type the performs the transformation.</typeparam>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddTransformationService<TSource, TDest, TTransform>(this IServiceCollection services)
            where TTransform : class, ITransform<TSource, TDest>
        {
            // Transformers
            services.AddSingleton<ITransform<TSource, TDest>, TTransform>();
            services.AddSingleton<ITransform, TTransform>();

            //Transformaion Service
            services.AddSingleton<IGenericTransformationService<TSource, TDest>, GenericTransformationService<TSource, TDest>>();
        }
    }
}
