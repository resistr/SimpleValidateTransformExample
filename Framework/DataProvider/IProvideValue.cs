namespace Framework.DataProvider
{
    public interface IProvideValue
    {
        object GetValue();
    }

    public interface IProvideValue<TValue> : IProvideValue
    {
        TValue Value { get; }
    }
}
