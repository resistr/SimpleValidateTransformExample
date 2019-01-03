using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// An interface describing the functionality of a keyed data provider.
    /// </summary>
    public interface IProvideKeyedData<TData>
        where TData : IProvideKey, IProvideValue
    {
        /// <summary>
        /// Gets the <see cref="IReadOnlyDictionary{object, IProvideValue}"/> of the keyed data.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The <see cref="IReadOnlyDictionary{object, IProvideValue}"/> provided by the provider.</returns>
        Task<IReadOnlyDictionary<object, IProvideValue>> GetReadOnlyDictionaryAsync(CancellationToken cancellationToken = default);
    }

    /// <summary>
    /// An interface describing the functionality of a strongly typed keyed data provider.
    /// </summary>
    /// <typeparam name="TKey">The item type.</typeparam>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    public interface IProvideKeyedData<TData, TKey, TValue> : IProvideKeyedData<TData>
        where TData : IProvideKey<TKey>, IProvideValue<TValue>
    {
        /// <summary>
        /// Gets the <see cref="IReadOnlyDictionary{TKey, TValue}"/> of the keyed data.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The <see cref="IReadOnlyDictionary{TKey, TValue}"/> provided by the provider.</returns>
        Task<IReadOnlyDictionary<TKey, TData>> GetTypedReadOnlyDictionaryAsync(CancellationToken cancellationToken = default);
    }
}
