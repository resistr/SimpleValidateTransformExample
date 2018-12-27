using Framework.Common;
using Framework.DataProvider;
using Framework.Derivation;
using Framework.Transformation;
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
            // add transformation
            services.AddScoped<ITransformationService, TransformationService>();

            // add derivation
            services.AddScoped<IDerivationService, DerivationService>();
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
