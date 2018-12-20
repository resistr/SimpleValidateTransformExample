using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;

namespace AspNet.DependencyInjection
{
    /// <summary>
    /// A scoped dependency injection container based on Microsoft.Extensions.DependencyInjection.
    /// </summary>
    public class ServiceProviderScopedDependencyResolver : IDependencyScope
    {
        protected readonly IServiceScope Scope;

        /// <summary>
        /// Initializes a new instance of the AspNet.DependencyInjection.ServiceProviderScopedDependencyResolver class.
        /// </summary>
        /// <param name="scope">The service scopr to use for dependency resolution.</param>
        public ServiceProviderScopedDependencyResolver(IServiceScope scope)
            => Scope = scope;

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>The retrieved service.</returns>
        public virtual object GetService(Type serviceType)
            => Scope.ServiceProvider.GetService(serviceType);

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>The retrieved collection of services.</returns>
        public virtual IEnumerable<object> GetServices(Type serviceType)
            => Scope.ServiceProvider.GetServices(serviceType);

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public virtual void Dispose()
            => Scope.Dispose();
    }
}
