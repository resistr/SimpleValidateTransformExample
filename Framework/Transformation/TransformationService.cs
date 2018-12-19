using System;

namespace Framework.Transformation
{
    public class TransformationService<TSource, TDest> : ITransformationService<TSource, TDest>
        where TSource : class
        where TDest : class
    {
        protected readonly ITransform<TSource, TDest> Transformer;

        public TransformationService(ITransform<TSource, TDest> transformer)
            => Transformer = transformer;

        public TDest Transform(TSource source)
        {
            try
            {
                return Transformer.Transform(source);
            }
            catch (Exception ex)
            {
                throw new TransformationException("Error running transformation.", Transformer, source, ex);
            }
        }
    }
}
