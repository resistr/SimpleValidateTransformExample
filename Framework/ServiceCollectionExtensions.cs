using Framework.Derivation;
using Framework.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace Framework
{
    public static class ServiceCollectionExtensions
    {
        public static void AddFrameworkServices(this IServiceCollection services)
        {
            services.AddScoped<IDerivationService, DerivationService>();
            services.AddScoped<IValidationService, ValidationService>();
        }
    }
}
