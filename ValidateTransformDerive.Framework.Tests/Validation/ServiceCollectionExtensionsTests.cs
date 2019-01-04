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
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class ServiceCollectionExtensionsTests
    {
        protected readonly Mock<IServiceCollection> ServiceCollectionMock = new Mock<IServiceCollection>();

        [TestMethod]
        public void AddValidatorTests()
        {
            ServiceCollectionMock.Object.AddValidator<Address, AddressValidator>();
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(AddressValidator) 
                        && desc.ServiceType == typeof(IValidator<Address>))), Times.Once);
            ServiceCollectionMock.Verify(
                serviceCollection => serviceCollection.Add(
                    It.Is<ServiceDescriptor>(
                        desc => desc.ImplementationType == typeof(AddressValidator)
                        && desc.ServiceType == typeof(IValidator))), Times.Once);
            ServiceCollectionMock.VerifyNoOtherCalls();
        }
    }
}
