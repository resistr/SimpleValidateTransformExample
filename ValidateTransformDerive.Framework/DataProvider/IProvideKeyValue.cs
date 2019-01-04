namespace ValidateTransformDerive.Framework.DataProvider
{
    public interface IProvideKeyValue : IProvideKey, IProvideValue { }

    public interface IProvideKeyValue<TKey, TValue> : IProvideKey<TKey>, IProvideValue<TValue>, IProvideKeyValue { }
}
