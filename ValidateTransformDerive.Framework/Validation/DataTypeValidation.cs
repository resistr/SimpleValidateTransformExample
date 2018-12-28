using System;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Static class of custom validation methods relating to validating data types. 
    /// </summary>
    public static class DataTypeValidation
    {
        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="bool"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a bool; otherwise false.</returns>
        public static bool Bool(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(bool));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="sbyte"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a sbyte; otherwise false.</returns>
        public static bool Sbyte(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(sbyte));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="short"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a short; otherwise false.</returns>
        public static bool Short(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(short));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="string"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a string; otherwise false.</returns>
        public static bool String(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(string));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="uint"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a uint; otherwise false.</returns>
        public static bool UInt(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(UInt32));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="char"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a char; otherwise false.</returns>
        public static bool Char(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(char));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="long"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a long; otherwise false.</returns>
        public static bool Long(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(Int64));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="int"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a int; otherwise false.</returns>
        public static bool Int(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(int));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="ulong"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a ulong; otherwise false.</returns>
        public static bool ULong(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(UInt64));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="float"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a float; otherwise false.</returns>
        public static bool Float(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(float));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="ushort"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a ushort; otherwise false.</returns>
        public static bool UShort(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(UInt16));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="double"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a double; otherwise false.</returns>
        public static bool Double(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(double));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="byte"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a byte; otherwise false.</returns>
        public static bool Byte(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(byte));

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is a <see cref="decimal"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a decimal; otherwise false.</returns>
        public static bool Decimal(object itemToValidate)
            => ConvertToValidate(itemToValidate, typeof(decimal));

        /// <summary>
        /// Uses <see cref="TimeSpan.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.TimeSpan"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a TimeSpan; otherwise false.</returns>
        public static bool TimeSpan(object itemToValidate)
            => System.TimeSpan.TryParse(itemToValidate?.ToString(), out TimeSpan result);

        /// <summary>
        /// Uses <see cref="DateTime.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.DateTime"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a DateTime; otherwise false.</returns>
        public static bool DateTime(object itemToValidate)
            => System.DateTime.TryParse(itemToValidate?.ToString(), out DateTime result);

        /// <summary>
        /// Uses <see cref="DateTimeOffset.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.DateTimeOffset"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a DateTimeOffset; otherwise false.</returns>
        public static bool DateTimeOffset(object itemToValidate)
            => System.DateTimeOffset.TryParse(itemToValidate?.ToString(), out DateTimeOffset result);

        /// <summary>
        /// Uses <see cref="Guid.TryParse(string, out System.TimeSpan)"/> to validate if itemToValidate is a <see cref="System.Guid"/>.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <returns>True if itemToValidate is a Guid; otherwise false.</returns>
        public static bool Guid(object itemToValidate)
            => System.Guid.TryParse(itemToValidate?.ToString(), out Guid result);

        /// <summary>
        /// Uses <see cref="Convert.ChangeType(object, Type)"/> to validate if itemToValidate is the expected type.
        /// </summary>
        /// <param name="itemToValidate">The item to validate.</param>
        /// <param name="conversionType">The type the item to validate is expected to be.</param>
        /// <returns>True if itemToValidate is a compatible with conversionType; otherwise false.</returns>
        private static bool ConvertToValidate(object itemToValidate, Type conversionType)
        {
            try
            {
                var convertedValue = Convert.ChangeType(itemToValidate, conversionType);
                return true;
            }
            catch (Exception ex)
            when (ex is InvalidCastException || ex is FormatException || ex is OverflowException || ex is ArgumentNullException)
            {
                return false;
            }
        }
    }
}
