namespace Framework.DataProvider
{
    public interface IProvideKey
    {
        object GetKey();
    }

    public interface IProvideKey<TKey> : IProvideKey
    {
        TKey Key { get; }
    }
}
