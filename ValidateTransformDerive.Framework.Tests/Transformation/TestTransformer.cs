using System;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Transformation
{
    public class TestTransformer<TSource, TDest> : TransformerBase<TSource, TDest>
    {
        protected readonly Func<TSource, TDest> TransformFunc;

        public TestTransformer(Func<TSource, TDest> func)
            => TransformFunc = func;

        public override TDest TransformInternal(TSource source)
            => TransformFunc(source);
    }
}
