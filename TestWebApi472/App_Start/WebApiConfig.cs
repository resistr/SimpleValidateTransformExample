using AspNet.DependencyInjection;
using Framework;
using Library;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Web.Http;

namespace TestWebApi472
{
    /// <summary>
    /// Static class providing the configuration implementation for <see cref="HttpConfiguration"/>.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Configures <see cref="HttpConfiguration"/> for the application. 
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/> to configure.</param>
        public static void Configure(HttpConfiguration config)
        {

            // Turn on XML seralization for WebApi
            config.Formatters.XmlFormatter.UseXmlSerializer = true;

            // add dependency resolution to the application 
            // based on Microsoft.Extensions.DependencyInjection
            config.BuildDependencyResolver(services => {

                // add a default memory cache based on Microsoft.Extensions.Caching.Memory
                services.AddMemoryCache();

                // add the default framework services (local project)
                services.AddFrameworkServices();

                // add the client specific services (local project)
                services.AddClientSpecificTransformations();
            });

            // configure attribute based routing
            config.MapHttpAttributeRoutes();

            // configure a default route.
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