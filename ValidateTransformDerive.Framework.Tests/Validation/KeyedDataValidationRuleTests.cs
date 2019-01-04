using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class KeyedDataValidationRuleTests
    {
        private readonly Mock<IProvideKeyValueData<TestKeyValueData<string, string>, string, string>> DataProviderMock
            = new Mock<IProvideKeyValueData<TestKeyValueData<string, string>, string, string>>();

        protected readonly string validKey = nameof(validKey);
        protected readonly string validValue = nameof(validValue);

        public KeyedDataValidationRuleTests()
        {
            DataProviderMock.Setup(provider => provider.GetTypedReadOnlyDictionaryAsync(It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(new Dictionary<string, string>()
                {
                    { validKey, validValue }
                } as IReadOnlyDictionary<string, string>));
        }

        [TestMethod]
        public void ValidateKeyValid()
            => CreateKeyValidator().ShouldNotHaveValidationErrorFor(prop => prop.Key, CreateData(validKey, null));

        [TestMethod]
        public void ValidateKeyNull()
            => CreateKeyValidator().ShouldHaveValidationErrorFor(prop => prop.Key, CreateData(null, validValue));

        [TestMethod]
        public void ValidateKeyError()
            => CreateKeyValidator().ShouldHaveValidationErrorFor(prop => prop.Key, CreateData(string.Empty, validValue));

        [TestMethod]
        public void ValidateValueValid()
            => CreateValueValidator().ShouldNotHaveValidationErrorFor(prop => prop.Value, CreateData(null, validValue));

        [TestMethod]
        public void ValidateValueNull()
            => CreateValueValidator().ShouldHaveValidationErrorFor(prop => prop.Value, CreateData(validKey, null));

        [TestMethod]
        public void ValidateValueError()
            => CreateValueValidator().ShouldHaveValidationErrorFor(prop => prop.Value, CreateData(validKey, string.Empty));

        private TestDataValidator<TestKeyValueData<string, string>> CreateKeyValidator()
            => new TestDataValidator<TestKeyValueData<string, string>>(
                v => v.RuleFor(d => d.Key).ValidateKey(DataProviderMock.Object)
                );

        private TestDataValidator<TestKeyValueData<string, string>> CreateValueValidator()
            => new TestDataValidator<TestKeyValueData<string, string>>(
                v => v.RuleFor(d => d.Value).ValidateValue(DataProviderMock.Object)
                );

        private TestKeyValueData<string, string> CreateData(string key, string value)
            => new TestKeyValueData<string, string> { Key = key, Value = value };
    }
}
