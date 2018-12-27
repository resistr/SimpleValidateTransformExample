﻿using System;
using System.Runtime.Serialization;

namespace Framework.Transformation
{
    /// <summary>
    /// Represents the exception that occurs during transformation of data when the
    /// Framework.Transformation.ITransformationService is used.
    /// </summary>
    [Serializable]
    public class TransformationException : Exception
    {
        /// <summary>
        /// The source type being transformed.
        /// </summary>
        public Type SourceType { get; private set; }

        /// <summary>
        /// The dest type being transformed.
        /// </summary>
        public Type DestType { get; private set; }

        /// <summary>
        /// The value being transformed.
        /// </summary>
        public object Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message, and the value being transformed.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="value">The value that was being transformed.</param>
        public TransformationException(string errorMessage, object value)
            : base(errorMessage)
            => Value = value;

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message, the value being transformed, and a collection of inner exception instances.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="value">The value that was being transformed.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public TransformationException(string errorMessage, object value, Exception innerException)
            : base(errorMessage, innerException)
            => Value = value;

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message, the value being transformed, and the transformer doing the 
        /// transformation.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="value">The value that was being transformed.</param>
        /// <param name="transform">The the transformer doing the transformation.</param>
        public TransformationException(string errorMessage, object value, Type sourceType, Type destType)
            : base(errorMessage)
        {
            SourceType = sourceType;
            DestType = destType;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message, the value being transformed, the transformer doing the 
        /// transformation, and a collection of inner exception instances.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="value">The value that was being transformed.</param>
        /// <param name="transform">The the transformer doing the transformation.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public TransformationException(string errorMessage, object value, Type sourceType, Type destType, Exception innerException)
            : base(errorMessage, innerException)
        {
            SourceType = sourceType;
            DestType = destType;
            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using an error message generated by the system.
        /// </summary>
        public TransformationException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public TransformationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.TransformationException class
        /// using a specified error message and a collection of inner exception instances.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public TransformationException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Transformation.ValidationException class using serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized data.</param>
        /// <param name="context">Context information about the source or destination of the serialized object.</param>
        protected TransformationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}