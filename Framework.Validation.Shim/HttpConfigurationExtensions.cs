using Microsoft.Extensions.DependencyInjection;
using System.Web.Http;
using System.Web.Http.Validation;

namespace Framework.Validation.Shim
{
    /// <summary>
    /// Provides extensions for System.Web.Http.HttpConfiguration
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        public static HttpConfiguration ConfigureServiceProviderValidator(this HttpConfiguration config, IServiceCollection services)
        {
            // remove the default ModelValidatorProvider
            config.Services.Clear(typeof(ModelValidatorProvider));

            // register ate service provider ModelValidatorProvider
            services.AddTransient<ModelValidatorProvider, ServiceProviderDataAnnotationsModelValidatorProvider>();

            // return the config for chaining. 
            return config;
        }
    }
}
