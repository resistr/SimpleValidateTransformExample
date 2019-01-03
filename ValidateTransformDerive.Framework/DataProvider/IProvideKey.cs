namespace ValidateTransformDerive.Framework.DataProvider
{

    public interface IProvideKey
    {
        object GetKey();
    }

    public interface IProvideKey<T> : IProvideKey
    {
        T Key { get; }
    }
}
