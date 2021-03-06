﻿using System;
using System.Runtime.Serialization;

namespace ValidateTransformDerive.Framework.Derivation
{
    /// <summary>
    /// Represents the exception that occurs during derivation of data when the
    /// <see cref="IDerivationService"/> is used.
    /// </summary>
    [Serializable]
    public class DerivationException : Exception
    {
        /// <summary>
        /// The type of the derivor.
        /// </summary>
        public Type DerivorType { get; private set; }

        /// <summary>
        /// The value of the source being derived.
        /// </summary>
        public object SourceValue { get; private set; }

        /// <summary>
        /// The value of the dest being derived.
        /// </summary>
        public object DestValue { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class
        /// using a specified error message, The type of derivor, the source value 
        /// to derive, and the dest value to derive.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="derivorType">The type of the derivor.</param>
        /// <param name="sourceValue">The value of the source.</param>
        /// <param name="destValue">The value of the dest.</param>
        public DerivationException(string errorMessage, Type derivorType, object sourceValue, object destValue)
            : base(errorMessage)
        {
            DerivorType = derivorType;
            SourceValue = sourceValue;
            DestValue = destValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class
        /// using a specified error message, The type of derivor, the source value 
        /// to derive, the dest value to derive, and an inner exception.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="derivorType">The type of the derivor.</param>
        /// <param name="sourceValue">The value of the source.</param>
        /// <param name="destValue">The value of the dest.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public DerivationException(string errorMessage, Type derivorType, object sourceValue, object destValue, Exception innerException)
            : base(errorMessage, innerException)
        {
            DerivorType = derivorType;
            SourceValue = sourceValue;
            DestValue = destValue;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class
        /// using an error message generated by the system.
        /// </summary>
        public DerivationException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class
        /// using a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public DerivationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class
        /// using a specified error message and a collection of inner exception instances.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The cof inner exception.</param>
        public DerivationException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivationException"/> class using serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized data.</param>
        /// <param name="context">Context information about the source or destination of the serialized object.</param>
        protected DerivationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
