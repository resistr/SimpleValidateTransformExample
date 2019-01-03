using FluentValidation;
using System;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Static class of custom validation methods relating to validating data types. 
    /// </summary>
    public static class DataTypeValidationRule
    {
        /// <summary>
        /// Validates if the value is compatible with type <see cref="bool"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsBool<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(bool))).CreateMessageCode(nameof(IsBool));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="sbyte"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsSByte<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(sbyte))).CreateMessageCode(nameof(IsSByte));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="short"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsShort<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(short))).CreateMessageCode(nameof(IsShort));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="string"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsString<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(string))).CreateMessageCode(nameof(IsString));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="uint"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsUInt<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(uint))).CreateMessageCode(nameof(IsUInt));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="sbyte"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsChar<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(char))).CreateMessageCode(nameof(IsChar));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="long"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsLong<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(long))).CreateMessageCode(nameof(IsLong));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="int"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsInt<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(int))).CreateMessageCode(nameof(IsInt));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="ulong"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsULong<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(ulong))).CreateMessageCode(nameof(IsULong));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="float"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsFloat<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(float))).CreateMessageCode(nameof(IsFloat));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="ushort"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsUShort<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(ushort))).CreateMessageCode(nameof(IsUShort));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="double"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsDouble<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(double))).CreateMessageCode(nameof(IsDouble));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="byte"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsByte<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(byte))).CreateMessageCode(nameof(IsByte));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="decimal"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsDecimal<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => ConvertToValidate(prop, typeof(decimal))).CreateMessageCode(nameof(IsDecimal));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="TimeSpan"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsTimeSpan<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => TimeSpan.TryParse(prop?.ToString(), out TimeSpan result)).CreateMessageCode(nameof(IsTimeSpan));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="DateTime"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsDateTime<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => DateTime.TryParse(prop?.ToString(), out DateTime result)).CreateMessageCode(nameof(IsDateTime));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsDateTimeOffset<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => DateTimeOffset.TryParse(prop?.ToString(), out DateTimeOffset result)).CreateMessageCode(nameof(IsDateTimeOffset));

        /// <summary>
        /// Validates if the value is compatible with type <see cref="Guid"/>.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> IsGuid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => Guid.TryParse(prop?.ToString(), out Guid result)).CreateMessageCode(nameof(IsGuid));

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
