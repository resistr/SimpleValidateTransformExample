using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Transformation
{
    public abstract class TransformerBase<TSource, TDest> : ITransform<TSource, TDest>
        where TSource : class
        where TDest : class
    {
        protected static readonly Type SourceType = typeof(TSource);
        protected static readonly Type DestType = typeof(TDest);

        public virtual bool CanTransform(Type source, Type dest)
            => SourceType == source && DestType == dest;

        public abstract TDest Transform(TSource source);

        public virtual IEnumerable<TDest> Transform(IEnumerable<TSource> source)
            => source.Select(item => Transform(item));

        object ITransform.Transform(object source)
            => Transform(source as TSource);
    }
}
