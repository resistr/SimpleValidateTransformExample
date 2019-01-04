using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class DataTypeValidationRuleTests
    {
        [TestMethod]
        public void IsBoolTests()
            => ValidateValueSet(builder => builder.IsBool(),
                new object[] { bool.TrueString, bool.FalseString, true, false }, 
                new object[] { string.Empty, null, nameof(IsBoolTests) });

        [TestMethod]
        public void IsSByteTests()
            => ValidateValueSet(builder => builder.IsSByte(),
                new object[] { sbyte.MinValue.ToString(), sbyte.MinValue.ToString(), sbyte.MinValue, sbyte.MaxValue },
                new object[] { $"{sbyte.MinValue}0", null, $"{sbyte.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsShortTests()
            => ValidateValueSet(builder => builder.IsShort(),
                new object[] { short.MinValue.ToString(), short.MinValue.ToString(), short.MinValue, short.MaxValue },
                new object[] { $"{short.MinValue}0", null, $"{short.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsUIntTests()
            => ValidateValueSet(builder => builder.IsUInt(),
                new object[] { uint.MinValue.ToString(), uint.MinValue.ToString(), uint.MinValue, uint.MaxValue },
                new object[] { "-1", null, $"{uint.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsCharTests()
            => ValidateValueSet(builder => builder.IsChar(),
                new object[] { char.MinValue.ToString(), char.MinValue.ToString(), char.MinValue, char.MaxValue, "x", 'x' },
                new object[] { "-1", null, $"{char.MaxValue}0", string.Empty, "XX", new { } });

        [TestMethod]
        public void IsLongTests()
            => ValidateValueSet(builder => builder.IsLong(),
                new object[] { long.MinValue.ToString(), long.MinValue.ToString(), long.MinValue, long.MaxValue },
                new object[] { $"{long.MinValue}1", null, $"{long.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsIntTests()
            => ValidateValueSet(builder => builder.IsInt(),
                new object[] { int.MinValue.ToString(), int.MinValue.ToString(), int.MinValue, int.MaxValue },
                new object[] { $"{int.MinValue}1", null, $"{int.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsULongTests()
            => ValidateValueSet(builder => builder.IsULong(),
                new object[] { ulong.MinValue.ToString(), ulong.MinValue.ToString(), ulong.MinValue, ulong.MaxValue },
                new object[] { "-1", null, $"{ulong.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsUShortTests()
            => ValidateValueSet(builder => builder.IsUShort(),
                new object[] { ushort.MinValue.ToString(), ushort.MinValue.ToString(), ushort.MinValue, ushort.MaxValue },
                new object[] { "-1", null, $"{ushort.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsDoubleTests()
            => ValidateValueSet(builder => builder.IsDouble(),
                new object[] { double.MinValue.ToString("R"), double.MinValue.ToString("R"), double.MinValue, double.MaxValue },
                new object[] { $"{double.MinValue}1", null, $"{double.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsDecimalTests()
            => ValidateValueSet(builder => builder.IsDecimal(),
                new object[] { decimal.MinValue.ToString(), decimal.MinValue.ToString(), decimal.MinValue, decimal.MaxValue },
                new object[] { $"{decimal.MinValue}1", null, $"{decimal.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsTimeSpanTests()
            => ValidateValueSet(builder => builder.IsTimeSpan(),
                new object[] { TimeSpan.MinValue.ToString(), TimeSpan.MinValue.ToString(), TimeSpan.MinValue, TimeSpan.MaxValue },
                new object[] { $"{TimeSpan.MinValue}1", null, $"{TimeSpan.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsDateTimeTests()
            => ValidateValueSet(builder => builder.IsDateTime(),
                new object[] { DateTime.MinValue.ToString(), DateTime.MinValue.ToString(), DateTime.MinValue, DateTime.MaxValue },
                new object[] { $"{DateTime.MinValue}1", null, $"{DateTime.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsDateTimeOffsetTests()
            => ValidateValueSet(builder => builder.IsDateTimeOffset(),
                new object[] { DateTimeOffset.MinValue.ToString(), DateTimeOffset.MinValue.ToString(), DateTimeOffset.MinValue, DateTimeOffset.MaxValue },
                new object[] { $"{DateTimeOffset.MinValue}1", null, $"{DateTimeOffset.MaxValue}0", string.Empty, new { } });

        [TestMethod]
        public void IsGuidTests()
            => ValidateValueSet(builder => builder.IsGuid(),
                new object[] { Guid.Empty.ToString(), Guid.NewGuid().ToString(), Guid.Empty, Guid.NewGuid() },
                new object[] { $"{Guid.Empty}1", null, $"{Guid.NewGuid()}0", string.Empty, new { } });

        private void ValidateValueSet(
            Action<IRuleBuilder<TestData<object>, object>> action, 
            IEnumerable<object> validValues, 
            IEnumerable<object> errorValues
            )
        {
            foreach (var value in validValues)
            {
                ShouldNotHaveValidationErrorFor(value, action);
            }

            foreach (var value in errorValues)
            {
                ShouldHaveValidationErrorFor(value, action);
            }
        }

        private void ShouldHaveValidationErrorFor<T>(T value, Action<IRuleBuilder<TestData<T>, T>> action)
            => CreateValidator(action)
            .ShouldHaveValidationErrorFor(prop => prop.Value, CreateData(value));

        private void ShouldNotHaveValidationErrorFor<T>(T value, Action<IRuleBuilder<TestData<T>, T>> action)
            => CreateValidator(action)
            .ShouldNotHaveValidationErrorFor(prop => prop.Value, CreateData(value));

        private TestDataValidator<TestData<T>> CreateValidator<T>(Action<IRuleBuilder<TestData<T>, T>> action)
            => new TestDataValidator<TestData<T>>(v => action(v.RuleFor(d => d.Value)));

        private TestData<T> CreateData<T>(T value)
            => new TestData<T> { Value = value };
    }
}
