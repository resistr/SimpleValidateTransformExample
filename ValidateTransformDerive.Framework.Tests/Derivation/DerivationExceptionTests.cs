using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ValidateTransformDerive.Framework.Derivation;

namespace ValidateTransformDerive.Framework.Tests.Derivation
{
    [TestClass]
    public class DerivationExceptionTests
    {
        protected readonly Type DerivorType = typeof(DerivationExceptionTests);
        protected readonly string ErrorMessage = nameof(DerivationExceptionTests);
        protected readonly Exception InnerException = new Exception();
        protected readonly object SourceValue = new object();
        protected readonly object DestValue = new object();

        [TestMethod]
        public void DerivationExceptionConstructorErrorMessageDerivorTypeSourceValueDestValueTest()
        {
            var exception = new DerivationException(ErrorMessage, DerivorType, SourceValue, DestValue);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.SourceValue, SourceValue);
            Assert.AreEqual(exception.DestValue, DestValue);
            Assert.AreEqual(exception.DerivorType, DerivorType);
        }

        [TestMethod]
        public void DerivationExceptionConstructorErrorMessageTransformTypeSourceValueDestValueInnerExceptionTest()
        {
            var exception = new DerivationException(ErrorMessage, DerivorType, SourceValue, DestValue, InnerException);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.InnerException, InnerException);
            Assert.AreEqual(exception.SourceValue, SourceValue);
            Assert.AreEqual(exception.DestValue, DestValue);
            Assert.AreEqual(exception.DerivorType, DerivorType);
        }

        [TestMethod]
        public void DerivationExceptionConstructor()
        {
            var exception = new DerivationException();
            Assert.IsInstanceOfType(exception, typeof(DerivationException));
        }

        [TestMethod]
        public void DerivationExceptionConstructorErrorMessageTest()
        {
            var exception = new DerivationException(ErrorMessage);
            Assert.AreEqual(exception.Message, ErrorMessage);
        }

        [TestMethod]
        public void DerivationExceptionConstructorErrorMessageInnerExceptionTest()
        {
            var exception = new DerivationException(ErrorMessage, InnerException);
            Assert.AreEqual(exception.Message, ErrorMessage);
            Assert.AreEqual(exception.InnerException, InnerException);
        }
    }
}
