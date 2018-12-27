using Microsoft.Extensions.DependencyInjection;
using System;

namespace Framework.Common
{
    /// <summary>
    /// Common extensions for <see cref="IServiceProvider"/>
    /// </summary>
    public static class ServiceProviderExtensions
    {

        /// <summary>
        /// Run all startup actions for this service provider. <see cref="IHaveStartupActions"/>
        /// </summary>
        /// <param name="serviceProvider">The service provider to run start up actions for.</param>
        public static void RunStartupActions(this IServiceProvider serviceProvider)
        {
            // create a scope services likely access data and are scoped
            using (var serviceScope = serviceProvider.CreateScope())
            {
                // get and run all startup actions
                serviceScope.ServiceProvider.GetServices<IHaveStartupActions>().Startup();
            }
        }
    }
}
