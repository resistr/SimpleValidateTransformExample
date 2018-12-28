using Microsoft.Extensions.DependencyInjection;

namespace ValidateTransformDerive.Framework.Transformation
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register transformation service. 
        /// 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddTransformationService<TSource, TDest, TTransform>(this IServiceCollection services)
            where TTransform : class, ITransform<TSource, TDest>
        {
            // transforms should not access any external data and should be thread safe so they should be singleton.
            services.AddSingleton<ITransform<TSource, TDest>, TTransform>();
            services.AddSingleton<ITransformationService<TSource, TDest>, TransformationService<TSource, TDest>>();
        }
    }
}
