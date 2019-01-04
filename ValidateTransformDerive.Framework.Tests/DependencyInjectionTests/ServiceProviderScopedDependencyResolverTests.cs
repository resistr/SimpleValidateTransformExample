using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using ValidateTransformDerive.Framework.DependencyInjection;

namespace ValidateTransformDerive.Framework.Tests.DependencyInjectionTests
{

    [TestClass]
    public class ServiceProviderScopedDependencyResolverTests
    {
        protected readonly Type ServiceScopeFactoryType = typeof(IServiceScopeFactory);
        protected readonly Type ServiceType = typeof(object);
        protected readonly Type ServicesType = typeof(IEnumerable<object>);
        protected readonly Mock<IServiceProvider> ServiceProviderMock = new Mock<IServiceProvider>();
        protected readonly Mock<IServiceScope> ServiceScopeMock = new Mock<IServiceScope>();
        protected readonly ServiceProviderScopedDependencyResolver ScopedDependencyResolver;

        public ServiceProviderScopedDependencyResolverTests()
            => ScopedDependencyResolver = new ServiceProviderScopedDependencyResolver(ServiceScopeMock.Object);

        [TestMethod]
        public void GetServiceDefersToProvider()
        {
            ServiceScopeMock.Setup(scope => scope.ServiceProvider).Returns(ServiceProviderMock.Object);
            ScopedDependencyResolver.GetService(ServiceType);
            ServiceProviderMock.Verify(provider => provider.GetService(ServiceType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
            ServiceScopeMock.Verify(scope => scope.ServiceProvider, Times.Once);
            ServiceScopeMock.VerifyNoOtherCalls();
            ServiceScopeMock.Reset();
        }

        [TestMethod]
        public void GetServicesDefersToProvider()
        {
            ServiceScopeMock.Setup(scope => scope.ServiceProvider).Returns(ServiceProviderMock.Object);
            ServiceProviderMock.Setup(provider => provider.GetService(ServicesType)).Returns(Enumerable.Empty<object>());
            ScopedDependencyResolver.GetServices(ServiceType);
            ServiceProviderMock.Verify(provider => provider.GetService(ServicesType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
            ServiceScopeMock.Verify(scope => scope.ServiceProvider, Times.Once);
            ServiceScopeMock.VerifyNoOtherCalls();
            ServiceScopeMock.Reset();
        }

        [TestMethod]
        public void DisposeCallsScopeDispose()
        {
            ScopedDependencyResolver.Dispose();
            ServiceScopeMock.Verify(disposable => disposable.Dispose(), Times.Once);
            ServiceScopeMock.VerifyNoOtherCalls();
            ServiceScopeMock.Reset();
        }
    }
}
