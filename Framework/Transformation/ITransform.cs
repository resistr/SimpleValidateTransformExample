using System;
using System.Collections.Generic;

namespace Framework.Transformation
{
    public interface ITransform
    {
        bool CanTransform(Type source, Type dest);

        object Transform(object source);
    }

    public interface ITransform<TSource, TDest> : ITransform
        where TSource : class
        where TDest : class
    {
        TDest Transform(TSource source);

        IEnumerable<TDest> Transform(IEnumerable<TSource> source);
    }
}
