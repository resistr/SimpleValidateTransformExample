﻿using System;

namespace ValidateTransformDerive.Framework.Transformation
{
    /// <summary>
    /// A strongly typed transformation service. 
    /// </summary>
    /// <typeparam name="TSource">The source type of the transformation.</typeparam>
    /// <typeparam name="TDest">The destination type of the transformation.</typeparam>
    public class TransformationService<TSource, TDest> : ITransformationService<TSource, TDest>
    {
        protected readonly ITransform<TSource, TDest> Transformer;

        /// <summary>
        ///  Initializes a new instance of the Framework.Transformation.TransformationService class.
        /// </summary>
        /// <param name="transformer">The transformer for the types transformed by this service.</param>
        public TransformationService(ITransform<TSource, TDest> transformer)
            => Transformer = transformer;

        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        public TDest Transform(TSource source)
        {
            try
            {
                // do the transform and return the result
                return Transformer.Transform(source);
            }
            catch (TransformationException) { throw; } // no need to wrap a transformation exception
            catch (Exception ex)
            {
                // failure; wrap the exception in a transformation exception
                throw new TransformationException("Error running transformation.", Transformer?.GetType(),  source, ex);
            }
        }
    }
}
