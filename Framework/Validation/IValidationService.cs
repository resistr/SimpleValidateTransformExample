namespace Framework.Validation
{
    public interface IValidationService
    {
        T Validate<T>(T source);
    }
}
