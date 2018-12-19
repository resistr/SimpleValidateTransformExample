using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace Framework.Validation
{
    [Serializable]
    public class ValidationException : System.ComponentModel.DataAnnotations.ValidationException
    {
        private IEnumerable<ValidationResult> _ValidationResults = Enumerable.Empty<ValidationResult>();
        private object _Value;

        public IEnumerable<ValidationResult> ValidationResults { get => _ValidationResults.Union(new[] { ValidationResult }); }

        public object ValidationValue { get => _Value ?? Value; }

        public ValidationException(string errorMessage, IEnumerable<ValidationResult> validationResults, object value)
            : base(errorMessage)
        {
            _Value = value;
            _ValidationResults = validationResults;
        }

        public ValidationException()
            : base()
        {
        }

        public ValidationException(string message)
            : base(message) { }

        public ValidationException(string message, Exception innerException)
            : base(message, innerException) { }

        protected ValidationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
