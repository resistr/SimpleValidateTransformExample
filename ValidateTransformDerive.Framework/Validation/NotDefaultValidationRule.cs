using FluentValidation;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Extensions for <see cref="IRuleBuilder{T, TProperty}"/> Fluent Validation validation rule builder.
    /// </summary>
    public static class NotDefaultValidationRule
    {
        /// <summary>
        /// Adds a validation rule to cause property value of default to cause validation failures.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> NotDefault<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => prop != default);
    }
}
