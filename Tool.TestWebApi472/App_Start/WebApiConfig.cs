using AutoMapper;
using FluentValidation;
using FluentValidation.WebApi;
using Framework.Common;
using Framework.DependencyInjection.Shim;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Web.Http;
using Tool.Framework;
using Tool.Framework.Validation.Shim;
using Tool.Library;
using Tool.Library.Validation;

namespace Tool.TestWebApi472
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

                // add the default framework services (local project)
                services.AddFrameworkServices();

                // add the automapper profiles
                services.AddAutoMapper(typeof(Library.Transform.SourceExampleToDestExampleProfile).Assembly);

                // add the client specific services (local project)
                services.AddClientSpecificTransformations();

                // add validators to the service provider
                foreach (var assemblyScanResult in AssemblyScanner.FindValidatorsInAssemblyContaining<SourceExampleValidator>())
                {
                    services.AddTransient(assemblyScanResult.InterfaceType, assemblyScanResult.ValidatorType);
                }
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
