using Framework.Transformation;
using Microsoft.Extensions.DependencyInjection;
using Tool.Framework.Transformation;

namespace Tool.Framework
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register default framework services. 
        /// 
        ///  - ITransformationService
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddFrameworkServices(this IServiceCollection services)
        {
            // add transformation
            services.AddScoped<ITransformationService, TransformationService>();
        }
    }
}
