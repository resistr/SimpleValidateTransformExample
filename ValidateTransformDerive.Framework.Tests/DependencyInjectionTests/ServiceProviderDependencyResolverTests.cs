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
    public class ServiceProviderDependencyResolverTests
    {
        protected readonly Type ServiceScopeFactoryType = typeof(IServiceScopeFactory);
        protected readonly Type ServiceType = typeof(object);
        protected readonly Type ServicesType = typeof(IEnumerable<object>);
        protected readonly Mock<IServiceProvider> ServiceProviderMock = new Mock<IServiceProvider>();
        protected readonly Mock<IServiceScope> ServiceScopeMock = new Mock<IServiceScope>();
        protected readonly Mock<IServiceScopeFactory> ServiceScopeFactoryMock = new Mock<IServiceScopeFactory>();
        protected readonly ServiceProviderDependencyResolver DependencyResolver;

        public ServiceProviderDependencyResolverTests()
            => DependencyResolver = new ServiceProviderDependencyResolver(ServiceProviderMock.Object);

        [TestMethod]
        public void GetServiceDefersToProvider()
        {
            DependencyResolver.GetService(ServiceType);
            ServiceProviderMock.Verify(provider => provider.GetService(ServiceType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
        }

        [TestMethod]
        public void GetServicesDefersToProvider()
        {
            ServiceProviderMock.Setup(provider => provider.GetService(ServicesType)).Returns(Enumerable.Empty<object>());
            DependencyResolver.GetServices(ServiceType);
            ServiceProviderMock.Verify(provider => provider.GetService(ServicesType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
        }

        [TestMethod]
        public void BeginScopeCallsProviderCreateScope()
        {
            ServiceProviderMock.Setup(provider => provider.GetService(ServiceScopeFactoryType)).Returns(ServiceScopeFactoryMock.Object);
            DependencyResolver.BeginScope();
            ServiceProviderMock.Verify(provider => provider.GetService(ServiceScopeFactoryType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
        }

        [TestMethod]
        public void BeginScopeReturnsServiceProviderScopedDependencyResolver()
        {
            ServiceProviderMock.Setup(provider => provider.GetService(ServiceScopeFactoryType)).Returns(ServiceScopeFactoryMock.Object);
            Assert.IsInstanceOfType(DependencyResolver.BeginScope(), typeof(ServiceProviderScopedDependencyResolver));
            ServiceProviderMock.Reset();
        }

        [TestMethod]
        public void BeginScopeIDependencyScopeHasProviderScope()
        {
            ServiceProviderMock.Setup(provider => provider.GetService(ServiceScopeFactoryType)).Returns(ServiceScopeFactoryMock.Object);
            ServiceScopeFactoryMock.Setup(factory => factory.CreateScope()).Returns(ServiceScopeMock.Object);
            ServiceScopeMock.Setup(scope => scope.ServiceProvider).Returns(ServiceProviderMock.Object);
            var scopedDependencyResolver = DependencyResolver.BeginScope();
            scopedDependencyResolver.GetService(ServiceType);
            ServiceProviderMock.Verify(provider => provider.GetService(ServiceScopeFactoryType), Times.Once);
            ServiceProviderMock.Verify(provider => provider.GetService(ServiceType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
            ServiceProviderMock.Reset();
            ServiceScopeFactoryMock.Verify(factory => factory.CreateScope(), Times.Once);
            ServiceScopeFactoryMock.VerifyNoOtherCalls();
            ServiceScopeFactoryMock.Reset();
            ServiceScopeMock.Verify(scope => scope.ServiceProvider, Times.Once);
            ServiceScopeMock.VerifyNoOtherCalls();
            ServiceScopeMock.Reset();
        }

        [TestMethod]
        public void DisposeHandlesIDisposableNull()
        {
            NullReferenceException thrownException = null;
            try
            {
                new ServiceProviderDependencyResolver(null).Dispose();
            }
            catch (NullReferenceException nex)
            {
                thrownException = nex;
            }

            Assert.IsNull(thrownException);
        }

        [TestMethod]
        public void DisposeCallsIDisposableDispose()
        {
            var mockServiceProvider = new Mock<IServiceProvider>();
            var mockDisposable = mockServiceProvider.As<IDisposable>();
            new ServiceProviderDependencyResolver(mockServiceProvider.Object).Dispose();
            mockDisposable.Verify(disposable => disposable.Dispose(), Times.Once);
            mockDisposable.VerifyNoOtherCalls();
        }
    }
}
