using FluentValidation;
using System.Linq;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// A validation rule for validating keyed data.
    /// </summary>
    public static class KeyedDataValidationRule
    {
        /// <summary>
        /// Validates if the value is present in the provided data by key.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <typeparam name="TData">The type of the data in the keyed value provider.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <param name="keyedDataProvider">The data provider for the rule.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> ValidateKey<T, TProperty, TData, TKey, TValue>
            (this IRuleBuilder<T, TProperty> rule,
            IProvideKeyValueData<TData, TKey, TValue> keyedDataProvider)
            where TData : IHaveKeyValue<TKey, TValue>
            where TProperty : TKey
            => rule.MustAsync(async (source, cancellationToken) =>
                source == null ? false : (await keyedDataProvider.GetTypedReadOnlyDictionaryAsync()).ContainsKey(source))
                .CreateMessageCode($"{nameof(ValidateKey)}.{typeof(TData).Name}");

        /// <summary>
        /// Validates if the value is present in the provided data by value.
        /// </summary>
        /// <typeparam name="T">The source type of the item being validated.</typeparam>
        /// <typeparam name="TProperty">The source type of the property being validated.</typeparam>
        /// <typeparam name="TData">The type of the data in the keyed value provider.</typeparam>
        /// <param name="ruleBuilder">The rule builder to add the rule to.</param>
        /// <param name="keyedDataProvider">The data provider for the rule.</param>
        /// <returns><see cref="IRuleBuilderOptions{T, TProperty}"/> for the new rule.</returns>
        public static IRuleBuilderOptions<T, TProperty> ValidateValue<T, TProperty, TData, TKey, TValue>
            (this IRuleBuilder<T, TProperty> ruleBuilder,
            IProvideKeyValueData<TData, TKey, TValue> keyedDataProvider)
            where TData : IHaveKeyValue<TKey, TValue>
            where TProperty : TValue
            => ruleBuilder.MustAsync(async (source, cancellationToken) =>
                (await keyedDataProvider.GetTypedReadOnlyDictionaryAsync()).Values.Any(value => value.Equals(source)))
            .CreateMessageCode($"{nameof(ValidateValue)}.{typeof(TData).Name}");
    }
}
