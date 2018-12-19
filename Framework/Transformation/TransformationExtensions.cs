using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Transformation
{
    public static class TransformationExtensions
    {

        public static bool CanTransform<FSource, FDest>(this ITransform transformer)
            => transformer.CanTransform(typeof(FSource), typeof(FDest));

        public static ITransform CanTransform(IEnumerable<ITransform> transformers, Type source, Type dest)
            => transformers.Single(transform => transform.CanTransform(source, dest));

        public static ITransform CanTransform<FSource, FDest>(IEnumerable<ITransform> transformers)
            where FSource : class
            where FDest : class
            => transformers.Single(transform => transform.CanTransform<FSource, FDest>());

        public static FDest Transform<FDest>(IEnumerable<ITransform> transformers, object source)
            where FDest : class
            => transformers.Single(transform => transform.CanTransform(source?.GetType(), typeof(FDest))).Transform(source) as FDest;

        public static FDest Transform<FSource, FDest>(IEnumerable<ITransform> transformers, FSource source)
            where FSource : class
            where FDest : class
            => transformers.Single(transform => transform.CanTransform<FSource, FDest>()).Transform<FSource, FDest>(source);

        public static FDest Transform<FSource, FDest>(this ITransform transformer, FSource source)
            where FSource : class
            where FDest : class
            => transformer.Transform(source as FSource) as FDest;

        public static IEnumerable<FDest> TransformMany<FSource, FDest>(this ITransform<FSource, FDest> transformer, IEnumerable<FSource> sourceItems)
            where FSource : class
            where FDest : class
            => sourceItems.Select(item => transformer.Transform(item));
    }
}
