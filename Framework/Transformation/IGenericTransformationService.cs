﻿namespace Framework.Transformation
{
    /// <summary>
    /// An interface describing the common functionality 
    /// of a strongly typed transformation service. 
    /// </summary>
    /// <typeparam name="TSource">The source type of the transformation.</typeparam>
    /// <typeparam name="TDest">The destination type of the transformation.</typeparam>
    public interface IGenericTransformationService<TSource, TDest>
        where TSource : class
        where TDest : class
    {
        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
        TDest Transform(TSource source);
    }
}
