using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Derivation
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        protected readonly Mock<IServiceCollection> ServiceCollectionMock = new Mock<IServiceCollection>();

        public class ServiceDerivor : TestDerivor<string, bool> { public ServiceDerivor() : base((s, b) => bool.Parse(s)) { } }

        [TestMethod]
        public void AddTransformationServiceTests()
        {
            ServiceCollectionMock.Object.AddDerivationService<string, bool, ServiceDerivor>();
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(ServiceDerivor) 
                        && desc.ServiceType == typeof(IDerive<string, bool>))), Times.Once);
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(DerivationService<string, bool>)
                        && desc.ServiceType == typeof(IDerivationService<string, bool>))), Times.Once);
            ServiceCollectionMock.VerifyNoOtherCalls();
        }
    }
}
