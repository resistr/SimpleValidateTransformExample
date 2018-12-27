using System.ComponentModel.DataAnnotations;

namespace Framework.Validation
{
    /// <summary>
    /// Static class of custom validation methods relating to validating data types. 
    /// </summary>
    public static class DataTypeValidations
    {
        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="bool"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Bool(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Bool(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="sbyte"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Sbyte(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Sbyte(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="short"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Short(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Short(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="string"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult String(object itemToValidate, ValidationContext context)
            => DataTypeValidation.String(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="uint"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult UInt(object itemToValidate, ValidationContext context)
            => DataTypeValidation.UInt(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="char"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Char(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Char(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="long"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Long(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Long(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="int"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Int(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Int(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="ulong"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult ULong(object itemToValidate, ValidationContext context)
            => DataTypeValidation.ULong(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="float"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Float(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Float(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="ushort"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult UShort(object itemToValidate, ValidationContext context)
            => DataTypeValidation.UShort(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="double"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Double(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Double(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="byte"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Byte(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Byte(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="decimal"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Decimal(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Decimal(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="TimeSpan.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.TimeSpan"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult TimeSpan(object itemToValidate, ValidationContext context)
            => DataTypeValidation.TimeSpan(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="DateTime.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult DateTime(object itemToValidate, ValidationContext context)
            => DataTypeValidation.DateTime(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="DateTimeOffset.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.DateTimeOffset"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult DateTimeOffset(object itemToValidate, ValidationContext context)
            => DataTypeValidation.DateTimeOffset(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Uses <see cref="Guid.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.Guid"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="context">The context of the item to validate.</param>
        /// <returns>A <see cref="ValidationResult"/> indicating the result of the validation.</returns>
        public static ValidationResult Guid(object itemToValidate, ValidationContext context)
            => DataTypeValidation.Guid(itemToValidate) ? Success : Failure;

        /// <summary>
        /// Shortcut to simplify returning validation success. 
        /// </summary>
        private static ValidationResult Success { get => ValidationResult.Success; }

        /// <summary>
        /// Shortcut to simplify returning validation failure. 
        /// </summary>
        private static ValidationResult Failure { get => new ValidationResult(null); }
    }
}
