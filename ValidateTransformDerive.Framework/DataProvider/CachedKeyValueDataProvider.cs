namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// An implementation of <see cref="IProvideKeyedData{TKey, TValue}"/>
    /// that provides cached key value data.
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public class CachedKeyValueDataProvider<TData, TKey, TValue>      
        : KeyValueDataProvider<TData, TKey, TValue>
        where TData : IHaveKeyValue<TKey, TValue>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericCachedKeyValueDataProvider{TData, TKey, TValue}"/> class.
        /// </summary>
        /// <param name="dataProvider">The cached data provider of the key value data.</param>
        public CachedKeyValueDataProvider(IProvideCachedData<TData> dataProvider) : base(dataProvider) { }
    }
}
