using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// An interface describing a validation rule for validating keyed data.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value; must implement <see cref="IProvideValue"/>.</typeparam>
    public interface IKeyedDataValidationRule<TKey, TValue>
        where TValue : IProvideValue
    {
        /// <summary>
        /// Validates if the key is present in the provided data.
        /// </summary>
        /// <param name="source">The key to validate.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be canceled.
        /// </param>
        /// <returns>A task representing the result of the validation.</returns>
        Task<bool> ValidateKeyAsync(TKey source, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validates if the value is present in the provided data.
        /// </summary>
        /// <param name="source">The value to validate.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be canceled.
        /// </param>
        /// <returns>A task representing the result of the validation.</returns>
        Task<bool> ValidateValueAsync(object source, CancellationToken cancellationToken = default);
    }
}
