﻿using System;
using System.Runtime.Serialization;

namespace ValidateTransformDerive.Framework.Transformation
{
    /// <summary>
    /// Represents the exception that occurs during derivation of data when the
    /// <see cref="ITransformationService"/> is used.
    /// </summary>
    [Serializable]
    public class TransformationException : Exception
    {
        /// <summary>
        /// The type of the transform.
        /// </summary>
        public Type TransformType { get; private set; }

        /// <summary>
        /// The value of the source being transformed.
        /// </summary>
        public object SourceValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class
        /// using a specified error message, The type of transformer, and the source value 
        /// to transform.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="transformType">The type of the transformer.</param>
        /// <param name="sourceValue">The value of the source.</param>
        public TransformationException(string errorMessage, Type transformType, object sourceValue)
            : base(errorMessage)
        {
            TransformType = transformType;
            SourceValue = sourceValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class
        /// using a specified error message, The type of transform, the source value 
        /// to transform, and an inner exception.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="derivorType">The type of the derivor.</param>
        /// <param name="sourceValue">The value of the source.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public TransformationException(string errorMessage, Type transformType, object sourceValue, Exception innerException)
            : base(errorMessage, innerException)
        {
            TransformType = transformType;
            SourceValue = sourceValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class
        /// using an error message generated by the system.
        /// </summary>
        public TransformationException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class
        /// using a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public TransformationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class
        /// using a specified error message and a collection of inner exception instances.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TransformationException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformationException"/> class using serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized data.</param>
        /// <param name="context">Context information about the source or destination of the serialized object.</param>
        protected TransformationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
