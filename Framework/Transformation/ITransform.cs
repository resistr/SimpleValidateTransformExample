using System;
using System.Collections.Generic;

namespace Framework.Transformation
{
    /// <summary>
    /// An interface describing the common functionality of all transformations.
    /// </summary>
    public interface ITransform
    {
        /// <summary>
        /// An indication of if this class can transform between the two types provided. 
        /// </summary>
        /// <param name="source">The type of the soruce object to transform.</param>
        /// <param name="dest">The type of the destination object to transform.</param>
        /// <returns>
        /// True if this transformer can transform between the soruce and destination
        /// types; otherwise false.
        /// </returns>
        bool CanTransform(Type source, Type dest);

        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        object Transform(object source);
    }

    /// <summary>
    /// An interface describing the common funcationality of 
    /// strongly typed transformations.
    /// </summary>
    /// <typeparam name="TSource">The source type of the transformation.</typeparam>
    /// <typeparam name="TDest">The destination type of the transformation.</typeparam>
    public interface ITransform<TSource, TDest> : ITransform
    {
        /// <summary>
        ///  Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        TDest Transform(TSource source);

        /// <summary>
        /// Transforms many items. 
        /// </summary>
        /// <param name="source">The list of items to transform.</param>
        /// <returns>The list of transformed items.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        IEnumerable<TDest> Transform(IEnumerable<TSource> source);
    }
}
