using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Serialization;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Transformation
{
    [TestClass]
    public class TransformationExceptionTests
    {
        protected readonly Type TransformType = typeof(TransformationExceptionTests);
        protected readonly string ErrorMessage = nameof(TransformationExceptionTests);
        protected readonly Exception InnerException = new Exception();

        [TestMethod]
        public void TransformationExceptionConstructorErrorMessageTransformTypeSourceValueTest()
        {
            var exception = new TransformationException(ErrorMessage, TransformType, this);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.SourceValue, this);
            Assert.AreEqual(exception.TransformType, TransformType);
        }

        [TestMethod]
        public void TransformationExceptionConstructorErrorMessageTransformTypeSourceValueInnerExceptionTest()
        {
            var exception = new TransformationException(ErrorMessage, TransformType, this, InnerException);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.InnerException, InnerException);
            Assert.AreEqual(exception.SourceValue, this);
            Assert.AreEqual(exception.TransformType, TransformType);
        }

        [TestMethod]
        public void TransformationExceptionConstructor()
        {
            var exception = new TransformationException();
            Assert.IsInstanceOfType(exception, typeof(TransformationException));
        }

        [TestMethod]
        public void TransformationExceptionConstructorErrorMessageTest()
        {
            var exception = new TransformationException(ErrorMessage);
            Assert.AreEqual(exception.Message, ErrorMessage);
        }

        [TestMethod]
        public void TransformationExceptionConstructorErrorMessageInnerExceptionTest()
        {
            var exception = new TransformationException(ErrorMessage, InnerException);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.InnerException, InnerException);
        }
    }
}
