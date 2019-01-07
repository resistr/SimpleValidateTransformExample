namespace ValidateTransformDerive.Framework
{
    public abstract class KeyValueBase<TKey, TValue> : IHaveKeyValue<TKey, TValue>
    {
        protected abstract TKey KeyInternal { get; }

        protected abstract TValue ValueInternal { get; }

        TKey IHaveKey<TKey>.Key => KeyInternal;

        TValue IHaveValue<TValue>.Value => ValueInternal;

        object IHaveKey.GetKey() => KeyInternal;

        object IHaveValue.GetValue() => ValueInternal;
    }
}
