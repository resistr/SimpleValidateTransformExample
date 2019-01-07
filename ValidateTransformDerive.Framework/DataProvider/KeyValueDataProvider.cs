using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// An implementation of <see cref="IProvideKeyedData{TKey, TValue}"/>
    /// that provides key value data.
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class KeyValueDataProvider<TData, TKey, TValue>      
        : IProvideKeyValueData<TData, TKey, TValue>
        where TData : IHaveKeyValue<TKey, TValue>
    {
        protected readonly IProvideData<TData> DataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericKeyValueDataProvider{TData, TKey, TValue}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider of the key value data.</param>
        public KeyValueDataProvider(IProvideData<TData> dataProvider)
            => DataProvider = dataProvider;

        /// <summary>
        /// Gets all items from the provider.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The untyped dictonary of key value data from the provider.</returns>
        public async Task<IReadOnlyDictionary<object, object>> GetReadOnlyDictionaryAsync(CancellationToken cancellationToken = default)
            => (await GetAllTypepdAsync(cancellationToken)).ToReadOnlyDictionary();

        /// <summary>
        /// Gets all items from the provider.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The typed dictonary of key value data from the provider.</returns>
        public async Task<IReadOnlyDictionary<TKey, TValue>> GetTypedReadOnlyDictionaryAsync(CancellationToken cancellationToken = default)
            => (await GetAllTypepdAsync(cancellationToken)).ToTypedReadOnlyDictionary();

        /// <summary>
        /// Tasks and implicit conversions are funky; hence this work around.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>A collection of items from the provider typed as <see cref="IHaveKeyValue{TKey, TValue}"/>.</returns>
        private async Task<IEnumerable<IHaveKeyValue<TKey, TValue>>> GetAllTypepdAsync(CancellationToken cancellationToken = default)
            => (await DataProvider.GetAllAsync(cancellationToken)).OfType<IHaveKeyValue<TKey, TValue>>();
    }
}
