namespace Framework.DataProvider
{
    /// <summary>
    /// An interface describing the functionality of a cached data provider.
    /// </summary>
    /// <typeparam name="T">The type of data the cached data provider provides.</typeparam>
    public interface IProvideCachedData<T> : IProvideData<T> { }
}
