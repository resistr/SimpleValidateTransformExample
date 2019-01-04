using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class SourceExampleValidatorTests
    {
        protected readonly SourceExampleValidator Validator = new SourceExampleValidator(new AddressValidator());
        protected static readonly string GuidEmpty = Guid.Empty.ToString();

        [TestMethod]
        public void TestRuleForAddressesValid()
            => Validator.ShouldNotHaveValidationErrorFor(ex => ex.Addresses, new[] { new Address() });

        [TestMethod]
        public void TestRuleForAddressesRequiredEmpty()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.Addresses, new Address[] { });

        [TestMethod]
        public void TestRuleForAddressesRequiredNull()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.Addresses, null as Address[]);

        [TestMethod]
        public void TestRuleForEachAddressesSetValidatorAddressValidator()
            => Validator.ShouldHaveChildValidator(x => x.Addresses, typeof(AddressValidator));

        [TestMethod]
        public void TestRuleForTestBoolValid()
            => Validator.StringIsRequired(ex => ex.TestBool, bool.FalseString, bool.TrueString);

        [TestMethod]
        public void TestRuleForTestBoolIsBoolError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestBool, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestByteValid()
            => Validator.StringIsRequired(ex => ex.TestByte, byte.MinValue, byte.MaxValue);

        [TestMethod]
        public void TestRuleForTestByteIsByteError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestByte, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestCharValid()
            => Validator.StringIsRequired(ex => ex.TestChar, Char.MinValue, Char.MaxValue);

        [TestMethod]
        public void TestRuleForTestCharIsCharError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestChar, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestDateTimeValid()
            => Validator.StringIsRequired(ex => ex.TestDateTime, DateTime.MinValue.ToString(), DateTime.MaxValue.ToString());

        [TestMethod]
        public void TestRuleForTestDateTimeIsDateTimeError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestDateTime, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestDateTimeOffsetValid()
            => Validator.StringIsRequired(ex => ex.TestDateTimeOffset, DateTimeOffset.MinValue.ToString(), DateTimeOffset.MaxValue.ToString());

        [TestMethod]
        public void TestRuleForTestDateTimeOffsetIsDateTimeOffsetError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestDateTimeOffset, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestDecimalValid()
            => Validator.StringIsRequired(ex => ex.TestDecimal, decimal.MinValue, decimal.MaxValue);

        [TestMethod]
        public void TestRuleForTestDecimalIsDecimalError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestDecimal, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestDoubleValid()
            => Validator.StringIsRequired(ex => ex.TestDouble, double.MinValue.ToString("R"), double.MaxValue.ToString("R"));

        [TestMethod]
        public void TestRuleForTestDoubleIsDoubleError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestDouble, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestFloatValid()
            => Validator.StringIsRequired(ex => ex.TestFloat, float.MinValue, float.MaxValue);

        [TestMethod]
        public void TestRuleForTestFloatIsFloatError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestFloat, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestGuidValid()
            => Validator.StringIsRequired(ex => ex.TestGuid, GuidEmpty, Guid.NewGuid().ToString());

        [TestMethod]
        public void TestRuleForTestGuidIsGuidError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestGuid, nameof(ValidateTransformDerive));

        [TestMethod]
        public void TestRuleForTestInt16Valid()
            => Validator.StringIsRequired(ex => ex.TestInt16, Int16.MinValue, Int16.MaxValue);

        [TestMethod]
        public void TestRuleForTestInt16IsShortError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestInt16, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestInt32Valid()
            => Validator.StringIsRequired(ex => ex.TestInt32, Int32.MinValue, Int32.MaxValue);

        [TestMethod]
        public void TestRuleForTestInt32IsIntError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestInt32, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestInt64Valid()
            => Validator.StringIsRequired(ex => ex.TestInt64, Int64.MinValue, Int64.MaxValue);

        [TestMethod]
        public void TestRuleForTestInt64IsLongError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestInt64, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestSbyteValid()
            => Validator.StringIsRequired(ex => ex.TestSbyte, sbyte.MinValue, sbyte.MaxValue);

        [TestMethod]
        public void TestRuleForTestSbyteIsSByteError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestSbyte, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestSingleValid()
            => Validator.StringIsRequired(ex => ex.TestSingle, Single.MinValue, Single.MaxValue);

        [TestMethod]
        public void TestRuleForTestSingleIsFloatError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestSingle, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestStringValid()
            => Validator.StringIsRequired(ex => ex.TestString, "Lazy");

        [TestMethod]
        public void TestRuleForTestTimeSpanValid()
            => Validator.StringIsRequired(ex => ex.TestTimeSpan, TimeSpan.MinValue.ToString(), TimeSpan.MaxValue.ToString());

        [TestMethod]
        public void TestRuleForTestTimeSpanIsTimeSpanError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestTimeSpan, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestUint16Valid()
            => Validator.StringIsRequired(ex => ex.TestUint16, UInt16.MinValue, UInt16.MaxValue);

        [TestMethod]
        public void TestRuleForTestUint16IsUShortError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestUint16, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestUint32Valid()
            => Validator.StringIsRequired(ex => ex.TestUint32, UInt32.MinValue, UInt32.MaxValue);

        [TestMethod]
        public void TestRuleForTestUint32IsUIntError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestUint32, GuidEmpty);

        [TestMethod]
        public void TestRuleForTestUint64Valid()
            => Validator.StringIsRequired(ex => ex.TestUint64, UInt64.MinValue, UInt64.MaxValue);

        [TestMethod]
        public void TestRuleForTestUint64IsULongError()
            => Validator.ShouldHaveValidationErrorFor(ex => ex.TestUint64, GuidEmpty);
    }
}
