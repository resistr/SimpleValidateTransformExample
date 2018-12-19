namespace Framework.Transformation
{
    public interface ITransformationService<TSource, TDest>
        where TSource : class
        where TDest : class
    {
        TDest Transform(TSource source);
    }
}
