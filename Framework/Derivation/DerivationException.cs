using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Framework.Derivation
{
    [Serializable]
    public class DerivationException : Exception
    {
        private IEnumerable<DerivationResult> _DerivationResults = Enumerable.Empty<DerivationResult>();

        private DerivationResult _DerivationResult;

        public IEnumerable<DerivationResult> ValidationResults { get => _DerivationResults.Union(new[] { DerivationResult }); }

        public DerivationAttribute DerivationAttribute { get; private set; }

        public DerivationResult DerivationResult
        {
            get
            {
                if (_DerivationResult == null)
                {
                    _DerivationResult = new DerivationResult(Message);
                }
                return _DerivationResult;
            }
        }

        public object Value { get; private set; }

        public DerivationException(string errorMessage, IEnumerable<DerivationResult> derivationResults, object value)
            : base(errorMessage)
        {
            Value = value;
            _DerivationResults = derivationResults;
        }

        public DerivationException(DerivationResult derivationResult, DerivationAttribute derivingAttribute, object value)
            : this(derivationResult.ErrorMessage, derivingAttribute, value)
        {
            _DerivationResult = derivationResult;
        }

        public DerivationException(string errorMessage, DerivationAttribute derivingAttribute, object value)
            : base(errorMessage)
        {
            Value = value;
            DerivationAttribute = derivingAttribute;
        }

        public DerivationException()
            : base()
        {
        }

        public DerivationException(string message)
            : base(message) { }

        public DerivationException(string message, Exception innerException)
            : base(message, innerException) { }

        protected DerivationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
