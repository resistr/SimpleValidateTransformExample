using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Validation
{
    public static class DataTypeValidations
    {

        public static ValidationResult ValidateBool(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(bool));

        public static ValidationResult ValidateSbyte(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(sbyte));

        public static ValidationResult ValidateInt16(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(Int16));

        public static ValidationResult ValidateString(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(string));

        public static ValidationResult ValidateUint32(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(UInt32));

        public static ValidationResult ValidateChar(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(char));

        public static ValidationResult ValidateInt64(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(Int64));

        public static ValidationResult ValidateInt32(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(int));

        public static ValidationResult ValidateUint64(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(UInt64));

        public static ValidationResult ValidateFloat(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(float));

        public static ValidationResult ValidateSingle(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(Single));

        public static ValidationResult ValidateUint16(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(UInt16));

        public static ValidationResult ValidateDouble(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(double));

        public static ValidationResult ValidateByte(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(byte));

        public static ValidationResult ValidateDecimal(object itemToValidate, ValidationContext context)
                => Validate(itemToValidate, context, typeof(Decimal));

        private static ValidationResult Validate(object itemToValidate, ValidationContext context, Type conversionType)
        {
            try
            {
                var convertedValue = Convert.ChangeType(itemToValidate, conversionType);
                return Success;
            }
            catch (Exception ex)
            when (ex is InvalidCastException || ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
            {
                return Failure;
            }
        }

        private static ValidationResult Success { get => ValidationResult.Success; }

        private static ValidationResult Failure { get => new ValidationResult(null); }

    }
}
