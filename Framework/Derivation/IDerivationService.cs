namespace Framework.Derivation
{
    public interface IDerivationService
    {
        T Derive<T>(T source);
    }
}
