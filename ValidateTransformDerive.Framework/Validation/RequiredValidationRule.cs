using FluentValidation;
using System;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Extensions for <see cref="IRuleBuilder{T, TProperty}"/> Fluent Validation validation rule builder.
    /// </summary>
    public static class RequiredValidationRule
    {

        /// <summary>
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>

        /// <summary>
        /// Adds a validation rule to validate required fields.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <param name="allowDefault">Specifies if default values should be allowed for value types.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> Required<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, bool allowDefault = false)
            => ruleBuilder.Must(prop => 
            {
                var isValid = prop != null;
                if (isValid && prop is string propAsString)
                {
                    isValid = !string.IsNullOrWhiteSpace(propAsString);
                }
                if (isValid && !allowDefault)
                {
                    var underlyingType = Nullable.GetUnderlyingType(typeof(TProperty));
                    if (underlyingType != null)
                    {
                        return typeof(TProperty)
                                .GetMethod(nameof(Nullable<int>.GetValueOrDefault))
                                .MakeGenericMethod(underlyingType)
                                .Invoke(prop, null) == default;
                    }
                    else
                    {
                        isValid = prop != default;
                    }
                }
                if (isValid && prop is Array propAsArray)
                {
                    isValid = propAsArray?.Length > 0;
                }
                return isValid;
            }).CreateMessageCode(nameof(Required));
    }
}
