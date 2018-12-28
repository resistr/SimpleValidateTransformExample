using Microsoft.Extensions.DependencyInjection;

namespace ValidateTransformDerive.Framework.Derivation
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register derivation service. 
        /// 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddDerivationService<TSource, TDest, TDerivor>(this IServiceCollection services)
            where TDerivor : class, IDerive<TSource, TDest>
        {
            // derivors may access any external data and should be thread safe so they should be scoped.
            services.AddScoped<IDerive<TSource, TDest>, TDerivor>();
            services.AddScoped<IDerivationService<TSource, TDest>, DerivationService<TSource, TDest>>();
        }
    }
}
