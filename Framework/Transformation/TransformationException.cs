using System;
using System.Runtime.Serialization;

namespace Framework.Transformation
{
    [Serializable]
    public class TransformationException : Exception
    {
        public ITransform Transform { get; private set; }

        public object Value { get; private set; }

        public TransformationException(string errorMessage, ITransform transform, object value)
            : base(errorMessage)
        {
            Transform = transform;
            Value = value;
        }

        public TransformationException(string errorMessage, ITransform transform, object value, Exception innerException)
            : base(errorMessage, innerException)
        {
            Transform = transform;
            Value = value;
        }

        public TransformationException()
            : base()
        {
        }

        public TransformationException(string message)
            : base(message) { }

        public TransformationException(string message, Exception innerException)
            : base(message, innerException) { }

        protected TransformationException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
}
