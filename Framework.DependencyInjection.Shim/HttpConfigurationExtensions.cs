using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Framework.DependencyInjection.Shim
{
    /// <summary>
    /// Provides extensions for System.Web.Http.HttpConfiguration
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        /// creates and builds a dependency resolver based on Microsoft.Extensions.DependencyInjection
        /// </summary>
        /// <param name="config">The System.Web.Http.HttpConfiguration to build the dependency resolver for.</param>
        /// <param name="serviceAction">The actions to take against the service collection. (Register service here)</param>
        /// <returns>The System.Web.Http.HttpConfiguration provided.</returns>
        public static IServiceProvider BuildDependencyResolver(this HttpConfiguration config, Action<IServiceCollection> serviceAction)
        {
            // Build a new service collection. 
            var services = new ServiceCollection();

            // run the provided actions against the service collection.
            serviceAction(services);

            // add all discovered controllers
            // assumed to be called from the WebApi project
            // TODO need to improve controller discovery.
            var controllerTypes = Assembly.GetCallingAssembly().GetExportedTypes()
              .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
              .Where(t => typeof(ApiController).IsAssignableFrom(t)
                || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase));
            foreach (var type in controllerTypes)
            {
                services.AddTransient(type);
            }

            // provide a method for accessing the provider by injecting IServiceProvider
            services.AddTransient(provider => provider);

            var serviceProvider = services.BuildServiceProvider();

            // set the default dependency resolver to the new service collection. 
            config.DependencyResolver = new ServiceProviderDependencyResolver(serviceProvider);

            // return the service provider for use. 
            return serviceProvider;
        }
    }
}
