using System;

namespace ValidateTransformDerive.Framework.Transformation
{
    /// <summary>
    /// A base class to provide common functionality to transformation classes.
    /// </summary>
    /// <typeparam name="TSource">The source type of the transformation.</typeparam>
    /// <typeparam name="TDest">The destination type of the transformation.</typeparam>
    public abstract class TransformerBase<TSource, TDest> : ITransform<TSource, TDest>
    {
        /// <summary>
        ///  Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        public abstract TDest TransformInternal(TSource source);

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
                // some unknown error occured in the transformation process; wrap it in a TransformationException
                // likely a transform had an uncaught exception
                throw new TransformationException("Error transforming.", GetType(), source, ex);
            }
        }
    }
}
