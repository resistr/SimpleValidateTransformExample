using FluentValidation.WebApi;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Web.Http;
using Tool.TestWebApi472.Controllers;
using ValidateTransformDerive.Framework;
using ValidateTransformDerive.Framework.DependencyInjection;
using ValidateTransformDerive.Framework.Validation;
using ValidateTransformDerive.ImplementationSpecific;

namespace ValidateTransformDerive.TestWebApi472
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Turn on XML seralization for WebApi
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // add dependency resolution to the application 
            // based on Microsoft.Extensions.DependencyInjection
            var serviceProvider = config.BuildDependencyResolver(services => {

                // add a default memory cache based on Microsoft.Extensions.Caching.Memory
                services.AddMemoryCache();

                // add the client specific services (local project)
                services.AddClientSpecificTransformations();

                // add controllers
                services.AddTransient<ConversionController>();

            });

            // add fluent validation 
            FluentValidationModelValidatorProvider.Configure(config, provider =>
            {
                // use a shim validation factory that uses the service provider
                // to obtain validations
                provider.ValidatorFactory = new ValidatorFactory(serviceProvider);
            });

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // run start up actions
            using (var serviceScope = config.DependencyResolver.BeginScope())
            {
                serviceScope.GetServices(typeof(IHaveStartupActions)).OfType<IHaveStartupActions>().Startup();
            }
        }
    }
}
