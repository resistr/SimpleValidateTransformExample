namespace Framework.DataProvider
{
    public interface IProvideKeyedValue : IProvideKey, IProvideValue { }

    public interface IProvideKeyedValue<TKey, TValue> : IProvideKey<TKey>, IProvideValue<TValue> { }
}
