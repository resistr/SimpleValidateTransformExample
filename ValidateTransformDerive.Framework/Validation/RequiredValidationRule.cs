using FluentValidation;
using System;
using System.Collections;
using System.Linq;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Extensions for <see cref="IRuleBuilder{T, TProperty}"/> Fluent Validation validation rule builder.
    /// </summary>
    public static class RequiredValidationRule
    {
        /// <summary>
        /// Adds a validation rule to validate required fields.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <param name="allowDefault">Specifies if default values should be allowed for value types.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowDefault = false)
            => ruleBuilder.Must(value => Required(value, allowDefault)).CreateMessageCode(nameof(Required));

        private static bool Required<T>(T value, bool allowDefault = false)
            => !IsNull(value) 
                && !IsNullOrWhiteSpace(value)
                && !IsEmptyArray(value)
                && (allowDefault ||
                    !IsDefault(value, Nullable.GetUnderlyingType(typeof(T))));

        private static bool IsNull<T>(T value)
            => value == null;

        private static bool IsNullOrWhiteSpace<T>(T value)
            => (value is string valueAsString) ? string.IsNullOrWhiteSpace(valueAsString) : false;

        private static bool IsEmptyArray<T>(T value)
            => (value is Array valueAsArray) ? valueAsArray.Length == 0 : false;

        private static bool IsDefault<T>(T value, Type underlyingType)
            => (underlyingType != null) ? IsNullNullableDefault(value, underlyingType) : value.Equals(Defaults.Default<T>()) == true;

        private static bool IsNullNullableDefault<T>(T value, Type underlyingType)
            => typeof(T)
            .GetProperty(nameof(Nullable<int>.Value))
            .GetValue(value)
            .Equals(Defaults.Default(underlyingType)) == true;
    }
}
