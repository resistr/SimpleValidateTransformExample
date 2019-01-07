namespace ValidateTransformDerive.Framework
{

    public interface IHaveKey
    {
        object GetKey();
    }

    public interface IHaveKey<T> : IHaveKey
    {
        T Key { get; }
    }
}
