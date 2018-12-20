using System;
using System.Collections.Generic;

namespace Framework.Transformation
{
    /// <summary>
    /// A transformation service. 
    /// </summary>
    public class TransformationService : ITransformationService
    {
        protected readonly IEnumerable<ITransform> Transformers;

        /// <summary>
        ///  Initializes a new instance of the Framework.Transformation.TransformationService class.
        /// </summary>
        /// <param name="transformers">The transformers for the types transformed by this service.</param>
        public TransformationService(IEnumerable<ITransform> transformers)
            => Transformers = transformers;

        /// <summary>
        /// An indication of if this class can transform between the two types provided. 
        /// </summary>
        /// <param name="source">The type of the soruce object to transform.</param>
        /// <param name="dest">The type of the destination object to transform.</param>
        /// <returns>
        /// True if this transformer can transform between the soruce and destination
        /// types; otherwise false.
        /// </returns>
        public bool CanTransform(Type source, Type dest)
            => (Transformers.CanTransform(source, dest) == null) ? false : true;

        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <typeparam name="TDest">The destination type to transform to.</typeparam>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public object Transform<TDest>(object source) where TDest : class
        {
            try
            {
                // do the transform and return the result
                return Transformers.Transform<TDest>(source);
            }
            catch (TransformationException) { throw; } // no need to wrap a transformation exception
            catch (Exception ex)
            {
                // some unknown error occured in the transformation process; wrap it in a ValidationException
                // likely a transform had an uncaught exception
                throw new TransformationException("Error transforming.", source, ex);
            }
        }
    }
}
