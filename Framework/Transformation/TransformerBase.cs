using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Transformation
{
    /// <summary>
    /// A base class to provide common functionality to transformation classes.
    /// </summary>
    /// <typeparam name="TSource">The source type of the transformation.</typeparam>
    /// <typeparam name="TDest">The destination type of the transformation.</typeparam>
    public abstract class TransformerBase<TSource, TDest> : ITransform<TSource, TDest>
    {
        // creating the types in advance once saves time later.
        protected static readonly Type SourceType = typeof(TSource);
        protected static readonly Type DestType = typeof(TDest);

        /// <summary>
        /// An indication of if this class can transform between the two types provided. 
        /// </summary>
        /// <param name="source">The type of the soruce object to transform.</param>
        /// <param name="dest">The type of the destination object to transform.</param>
        /// <returns>
        /// True if this transformer can transform between the soruce and destination
        /// types; otherwise false.
        /// </returns>
        public virtual bool CanTransform(Type source, Type dest)
            => SourceType == source && DestType == dest;

        /// <summary>
        ///  Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        public abstract TDest TransformInternal(TSource source);

        /// <summary>
        /// Transforms many items. 
        /// </summary>
        /// <param name="source">The list of items to transform.</param>
        /// <returns>The list of transformed items.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public virtual IEnumerable<TDest> Transform(IEnumerable<TSource> source)
            => source.Select(item => Transform(item));

        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        /// <exception cref="InvalidCastException">The source was not of the proper type.</exception>
        object ITransform.Transform(object source)
            => Transform((TSource)source);

        /// <summary>
        ///  Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public TDest Transform(TSource source)
        {
            try
            {
                // do the transform and return the result
                return TransformInternal(source);
            }
            catch (TransformationException) { throw; } // no need to wrap a transformation exception
            catch (Exception ex)
            {
                // some unknown error occured in the transformation process; wrap it in a ValidationException
                // likely a transform had an uncaught exception
                throw new TransformationException("Error transforming.", source, typeof(TSource), typeof(TDest), ex);
            }
        }
    }
}
