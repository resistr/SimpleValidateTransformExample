using FluentValidation;
using FluentValidation.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class ValidatorFactoryTests
    {

        private class TestValidator : IValidator
        {
            public bool CanValidateInstancesOfType(Type type)
            {
                throw new NotImplementedException();
            }

            public IValidatorDescriptor CreateDescriptor()
            {
                throw new NotImplementedException();
            }

            public ValidationResult Validate(object instance)
            {
                throw new NotImplementedException();
            }

            public ValidationResult Validate(ValidationContext context)
            {
                throw new NotImplementedException();
            }

            public Task<ValidationResult> ValidateAsync(object instance, CancellationToken cancellation = default(CancellationToken))
            {
                throw new NotImplementedException();
            }

            public Task<ValidationResult> ValidateAsync(ValidationContext context, CancellationToken cancellation = default(CancellationToken))
            {
                throw new NotImplementedException();
            }
        }

        protected readonly Mock<IServiceProvider> ServiceProviderMock = new Mock<IServiceProvider>();
        protected readonly ValidatorFactory ValidatorFactory;
        protected static readonly Type ValidatorType = typeof(TestValidator);

        public ValidatorFactoryTests()
        {
            ValidatorFactory = new ValidatorFactory(ServiceProviderMock.Object);
        }

        [TestMethod]
        public void CreateInstanceDefersToServiceProvider()
        {
            ServiceProviderMock.Setup(provider => provider.GetService(ValidatorType)).Returns(new TestValidator());
            var validator = ValidatorFactory.CreateInstance(ValidatorType);
            Assert.IsInstanceOfType(validator, ValidatorType);
            ServiceProviderMock.Verify(provider => provider.GetService(ValidatorType), Times.Once);
            ServiceProviderMock.VerifyNoOtherCalls();
        }
    }
}
