using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// A validation rule for validating keyed data.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value; must implement <see cref="IProvideValue"/>.</typeparam>
    public class KeyedDataValidationRule<TKey, TValue> : IKeyedDataValidationRule<TKey, TValue>
        where TValue : IProvideValue
    {
        /// <summary>
        /// The DI injected <see cref="IProvideKeyedData{TKey, TValue}"/> to use for validation.
        /// </summary>
        protected readonly IProvideKeyedData<TKey, TValue> KeyedDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedDataValidationRule{TKey, TValue}" /> class.
        /// </summary>
        /// <param name="keyedDataProvider">
        /// The <see cref="IProvideKeyedData{TKey, TValue}"/> to use for validation.
        /// </param>
        public KeyedDataValidationRule(IProvideKeyedData<TKey, TValue> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        /// <summary>
        /// Validates if the key is present in the provided data.
        /// </summary>
        /// <param name="source">The key to validate.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be canceled.
        /// </param>
        /// <returns>A task representing the result of the validation.</returns>
        public async Task<bool> ValidateKeyAsync(TKey source, CancellationToken cancellationToken = default)
            => (await KeyedDataProvider.GetTypedReadOnlyDictionaryAsync()).ContainsKey(source);

        /// <summary>
        /// Validates if the value is present in the provided data.
        /// </summary>
        /// <param name="source">The value to validate.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be canceled.
        /// </param>
        /// <returns>A task representing the result of the validation.</returns>
        public async Task<bool> ValidateValueAsync(object source, CancellationToken cancellationToken = default)
            => (await KeyedDataProvider.GetTypedReadOnlyDictionaryAsync()).Values.Any(value => value.GetValue() == source);
    }
}
