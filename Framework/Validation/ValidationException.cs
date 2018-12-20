﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Framework.Validation
{
    /// <summary>
    /// Represents the exception that occurs during validation of data when the
    /// Framework.Validation.IValidationService is used.
    /// </summary>
    [Serializable]
    public class ValidationException : System.ComponentModel.DataAnnotations.ValidationException
    {
        private IEnumerable<ValidationResult> _ValidationResults = Enumerable.Empty<ValidationResult>();
        private object _Value;

        /// <summary>
        /// Gets the validation results that causes the Framework.Validation.ValidationException exception.
        /// </summary>
        public IEnumerable<ValidationResult> ValidationResults { get => _ValidationResults.Union(new[] { ValidationResult }); }

        /// <summary>
        /// Gets the value of the object that causes the Framework.Validation.ValidationException exception.
        /// </summary>
        public object ValidationValue { get => _Value ?? Value; }

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationException class
        /// using a specified error message, a list of validation results and the value being validated.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="validationResults">The validation results.</param>
        /// <param name="value">The value that was validated.</param>
        public ValidationException(string errorMessage, IEnumerable<ValidationResult> validationResults, object value)
            : base(errorMessage)
        {
            _Value = value;
            _ValidationResults = validationResults;
        }

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationException class
        /// using an error message generated by the system.
        /// </summary>
        public ValidationException()
            : base() { }

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationException class
        /// using a specified error message.
        /// </summary>
        /// <param name="message">The error message.</param>
        public ValidationException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationException class
        /// using a specified error message and a collection of inner exception instances.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The collection of inner exceptions.</param>
        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationException class using serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized data.</param>
        /// <param name="context">Context information about the source or destination of the serialized object.</param>
        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
