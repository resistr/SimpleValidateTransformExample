using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Transformation
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        protected readonly Mock<IServiceCollection> ServiceCollectionMock = new Mock<IServiceCollection>();

        public class ServiceTransformer : TestTransformer<string, bool> { public ServiceTransformer() : base(bool.Parse) { } }

        [TestMethod]
        public void AddTransformationServiceTests()
        {
            ServiceCollectionMock.Object.AddTransformationService<string, bool, ServiceTransformer>();
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(ServiceTransformer) 
                        && desc.ServiceType == typeof(ITransform<string, bool>))), Times.Once);
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(TransformationService<string, bool>)
                        && desc.ServiceType == typeof(ITransformationService<string, bool>))), Times.Once);
            ServiceCollectionMock.VerifyNoOtherCalls();
        }
    }
}
