using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class RequiredValidationRuleTests
    {
        [TestMethod]
        public void IsNullTest()
            => ShouldHaveValidationErrorFor<string>(null);

        [TestMethod]
        public void IsNullOrWhiteSpaceTest()
            => ShouldHaveValidationErrorFor("     ");

        [TestMethod]
        public void IsEmptyArrayTest()
            => ShouldHaveValidationErrorFor(new string[] { });

        [TestMethod]
        public void IsNullNullableDefaultTest()
            => ShouldHaveValidationErrorFor<int?>(Defaults.Default<int>());

        [TestMethod]
        public void IsDefaultTest()
            => ShouldHaveValidationErrorFor<int>(default);

        [TestMethod]
        public void IsValidTest()
            => ShouldNotHaveValidationErrorFor<int>(1);

        [TestMethod]
        public void BypassIsNullNullableDefaultTest()
            => ShouldNotHaveValidationErrorFor<int?>(Defaults.Default<int>(), true);

        [TestMethod]
        public void BypassIsDefaultTest()
            => ShouldNotHaveValidationErrorFor<int>(default, true);

        private void ShouldHaveValidationErrorFor<T>(T value, bool allowDefault = false)
            => CreateValidator<T>(allowDefault)
            .ShouldHaveValidationErrorFor(prop => prop.Value, CreateData(value));

        private void ShouldNotHaveValidationErrorFor<T>(T value, bool allowDefault = false)
            => CreateValidator<T>(allowDefault)
            .ShouldNotHaveValidationErrorFor(prop => prop.Value, CreateData(value));

        private TestDataValidator<TestData<T>> CreateValidator<T>(bool allowDefault = false)
            => new TestDataValidator<TestData<T>>(v => v.RuleFor(d => d.Value).Required(allowDefault));

        private TestData<T> CreateData<T>(T value)
            => new TestData<T> { Value = value };
    }
}
