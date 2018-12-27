namespace Framework.DataProvider
{

    public interface IProvideValue
    {
        object GetValue();
    }

    public interface IProvideValue<T> : IProvideValue
    {
        T Value { get; }
    }
}
