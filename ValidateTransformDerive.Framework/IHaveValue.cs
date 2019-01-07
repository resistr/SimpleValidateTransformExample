namespace ValidateTransformDerive.Framework
{

    public interface IHaveValue
    {
        object GetValue();
    }

    public interface IHaveValue<T> : IHaveValue
    {
        T Value { get; }
    }
}
