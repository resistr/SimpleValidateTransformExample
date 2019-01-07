namespace ValidateTransformDerive.Framework
{
    public interface IHaveKeyValue : IHaveKey, IHaveValue { }

    public interface IHaveKeyValue<TKey, TValue> : IHaveKey<TKey>, IHaveValue<TValue>, IHaveKeyValue { }
}
