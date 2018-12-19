namespace Framework.DataProvider
{
    public abstract class KeyedValueBase<TKey, TValue> : IProvideKeyedValue<TKey, TValue>, IProvideKeyedValue
    {
        public virtual TKey Key { get; set; }

        public virtual TValue Value { get; set; }

        public object GetKey()
            => Key;

        public object GetValue()
            => Value;
    }
}
