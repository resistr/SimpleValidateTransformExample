using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Http;
using ValidateTransformDerive.Framework.DependencyInjection;

namespace ValidateTransformDerive.Framework.Tests.DependencyInjectionTests
{
    [TestClass]
    public class HttpConfigurationExtensionsTests
    {
        protected readonly Type ServiceProviderType = typeof(IServiceProvider);
        protected readonly HttpConfiguration Config = new HttpConfiguration();
        protected readonly IServiceProvider ServiceProvider;

        public HttpConfigurationExtensionsTests()
            => ServiceProvider = Config.BuildDependencyResolver(services =>
            {
                services.AddSingleton(this);
            });


        [TestMethod]
        public void ReturnsServiceProvider()
            => Assert.IsNotNull(ServiceProvider);

        [TestMethod]
        public void RunsServiceAction()
            => Assert.AreEqual(this, ServiceProvider.GetService<HttpConfigurationExtensionsTests>());

        [TestMethod]
        public void AddsServiceProviderToCollection()
            => Assert.IsInstanceOfType(ServiceProvider.GetService<IServiceProvider>(), ServiceProviderType);

        [TestMethod]
        public void SetsDependencyResolver()
            => Assert.IsInstanceOfType(Config.DependencyResolver, typeof(ServiceProviderDependencyResolver));

        [TestMethod]
        public void DependencyResolverHasServiceProvider()
            => Assert.IsInstanceOfType(Config.DependencyResolver.GetService(typeof(IServiceProvider)), ServiceProviderType);
    }
}
