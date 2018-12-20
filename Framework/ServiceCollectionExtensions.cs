using Framework.Derivation;
using Framework.Validation;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
