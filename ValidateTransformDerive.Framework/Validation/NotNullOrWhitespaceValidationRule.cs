using FluentValidation;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Extensions for <see cref="IRuleBuilder{T, TProperty}"/> Fluent Validation validation rule builder.
    /// </summary>
    public static class NotNullOrWhiteSpaceValidationRule
    {
        /// <summary>
        /// Adds a validation rule to cause <see cref="string.IsNullOrWhiteSpace(string)"/> failuers to cause validation failures.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, string> NotNullOrWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder.Must(prop => !string.IsNullOrWhiteSpace(prop));
    }
}
