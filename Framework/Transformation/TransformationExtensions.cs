using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Transformation
{
    /// <summary>
    /// Common extensions to Framework.Transformation.ITransform.  
    /// </summary>
    public static class TransformationExtensions
    {

        /// <summary>
        /// Generic helper for can transform.
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <param name="transformer">The transformer to verify can transform the provided types.</param>
        /// <returns>
        /// True if this transformer can transform between the soruce and destination
        /// types; otherwise false.
        /// </returns>
        public static bool CanTransform<FSource, FDest>(this ITransform transformer)
            => transformer.CanTransform(typeof(FSource), typeof(FDest));

        /// <summary>
        /// Get the single transform that can transform the types provided. 
        /// </summary>
        /// <param name="Source">The source type.</typeparam>
        /// <param name="Dest">The destination type.</typeparam>
        /// <param name="transformers">The transformers find the transform to do the transformation with.</param>
        /// <returns>The single transform that is able to transform the types.</returns>
        /// <exception cref="TransformationException">Thrown if no or many transforms can transform the type.</exception>
        public static ITransform CanTransform(this IEnumerable<ITransform> transformers, Type source, Type dest)
            => transformers.Where(transform => transform.CanTransform(source, dest)).VerifyOne(() => None(source, dest), () => Many(source, dest));

        /// <summary>
        /// Get the single transform that can transform the types provided. 
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <param name="transformers">The transformers find the transform to do the transformation with.</param>
        /// <returns>The single transform that is able to transform the types.</returns>
        /// <exception cref="TransformationException">Thrown if no or many transforms can transform the type.</exception>
        public static ITransform CanTransform<FSource, FDest>(this IEnumerable<ITransform> transformers)
            where FSource : class
            where FDest : class
            => transformers.Where(transform => transform.CanTransform<FSource, FDest>()).VerifyOne(() => None<FSource, FDest>(), () => Many<FSource, FDest>());

        /// <summary>
        /// Do a generic transform from a collection of transforms.
        /// Finds the transform that can do the transformation and calls the transform method.
        /// </summary>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <param name="transformers">The transformers find the transform to do the transformation with.</param>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The transformed item; or null if the transform was of incompatible types.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public static FDest Transform<FDest>(this IEnumerable<ITransform> transformers, object source)
            where FDest : class
            => transformers.CanTransform(source?.GetType(), typeof(FDest)).Transform(source) as FDest;

        /// <summary>
        /// Do a generic transform from a collection of transforms.
        /// Finds the transform that can do the transformation and calls the transform method.
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <param name="transformers">The transformers find the transform to do the transformation with.</param>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The transformed item; or null if the transform was of incompatible types.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public static FDest Transform<FSource, FDest>(this IEnumerable<ITransform> transformers, FSource source)
            where FSource : class
            where FDest : class
            => transformers.CanTransform<FSource, FDest>().Transform<FSource, FDest>(source);

        /// <summary>
        /// Do a generic transform from a single transform.
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <param name="transformer">The transformer to do the transformation with.</param>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The transformed item; or null if the transform was of incompatible types.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public static FDest Transform<FSource, FDest>(this ITransform transformer, FSource source)
            where FSource : class
            where FDest : class
            => transformer.Transform(source as FSource) as FDest;

        /// <summary>
        /// Helper for generating a <see cref="TransformationException"/> when more than one transform can transform the types.
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <returns>A transformation exception.</returns>
        private static TransformationException Many<FSource, FDest>()
            => Many(typeof(FSource), typeof(FDest));

        /// <summary>
        /// Helper for generating a <see cref="TransformationException"/> when no transforms can transform the types.
        /// </summary>
        /// <typeparam name="FSource">The source type.</typeparam>
        /// <typeparam name="FDest">The destination type.</typeparam>
        /// <returns>A transformation exception.</returns>
        private static TransformationException None<FSource, FDest>()
            => None(typeof(FSource), typeof(FDest));

        /// <summary>
        /// Helper for generating a <see cref="TransformationException"/> when more than one transform can transform the types.
        /// </summary>
        /// <param name="source">The source type.</param>
        /// <param name="dest">The destination type.</param>
        /// <returns>A transformation exception.</returns>
        private static TransformationException Many(Type source, Type dest)
            => new TransformationException($"Many transformations found able to transform between {source?.FullName ?? "{null}"} and {dest?.FullName ?? "{null}"}");

        /// <summary>
        /// Helper for generating a <see cref="TransformationException"/> when no transforms can transform the types.
        /// </summary>
        /// <param name="source">The source type.</param>
        /// <param name="dest">The destination type.</param>
        /// <returns>A transformation exception.</returns>
        private static TransformationException None(Type source, Type dest)
            => new TransformationException($"No transformations found able to transform between {source?.FullName ?? "{null}"} and {dest?.FullName ?? "{null}"}");
    }
}
