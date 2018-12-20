using System;

namespace Framework.Transformation
{
    /// <summary>
    /// An interface describing the common functionality 
    /// of a transformation service. 
    /// </summary>
    public interface ITransformationService
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
        /// <typeparam name="TDest">The destination type to transform to.</typeparam>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        object Transform<TDest>(object source) where TDest : class;
    }
}
