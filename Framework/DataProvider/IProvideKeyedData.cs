﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    /// <summary>
    /// An interface describing the functionality of a keyed data provider.
    /// </summary>
    public interface IProvideKeyedData
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
    public interface IProvideKeyedData<TKey, TValue> : IProvideKeyedData
        where TValue : IProvideValue
    {
        /// <summary>
        /// Gets the <see cref="IReadOnlyDictionary{TKey, TValue}"/> of the keyed data.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The <see cref="IReadOnlyDictionary{TKey, TValue}"/> provided by the provider.</returns>
        Task<IReadOnlyDictionary<TKey, TValue>> GetTypedReadOnlyDictionaryAsync(CancellationToken cancellationToken = default);
    }
}
