using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace Framework.DependencyInjection.Shim
{
    /// <summary>
    /// A dependency injection container based on Microsoft.Extensions.DependencyInjection.
    /// </summary>
    public class ServiceProviderDependencyResolver : IDependencyResolver
    {
        protected readonly IServiceProvider Provider;

        /// <summary>
        /// Initializes a new instance of the AspNet.DependencyInjection.ServiceProviderDependencyResolver class.
        /// </summary>
        /// <param name="provider">The service provider to use for dependency resolution.</param>
        public ServiceProviderDependencyResolver(IServiceProvider provider)
            => Provider = provider;

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>The retrieved service.</returns>
        public virtual object GetService(Type serviceType)
            => Provider.GetService(serviceType);

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>The retrieved collection of services.</returns>
        public virtual IEnumerable<object> GetServices(Type serviceType)
            => Provider.GetServices(serviceType);

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>The dependency scope.</returns>
        public virtual IDependencyScope BeginScope()
            => new ServiceProviderScopedDependencyResolver(Provider.CreateScope());

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
            => (Provider as ServiceProvider)?.Dispose();
    }
}
