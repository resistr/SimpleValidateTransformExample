using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Transformation
{
    [TestClass]
    public class TransformationServiceTests
    {
        protected readonly Exception GeneralException = new Exception();
        protected readonly TransformationException TransformationException = new TransformationException();
        protected readonly Mock<ITransform<string, bool>> TransformerMock = new Mock<ITransform<string, bool>>();
        protected readonly TransformationService<string, bool> TransformationService;

        public TransformationServiceTests()
        {
            TransformationService = new TransformationService<string, bool>(TransformerMock.Object);
        }

        [TestMethod]
        public void CallsTransformInternal()
        {
            TransformationService.Transform(null);
            TransformerMock.Verify(transform => transform.Transform(null), Times.Once);
            TransformerMock.VerifyNoOtherCalls();
            TransformerMock.Reset();
        }

        [TestMethod]
        public void RethrowsTransformException()
        {
            TransformationException thrownEx = null;
            try
            {
                TransformerMock.Setup(transform => transform.Transform(null)).Throws(TransformationException);
                TransformationService.Transform(null);
            }
            catch (TransformationException tex)
            {
                thrownEx = tex;
            }
            Assert.AreEqual(TransformationException, thrownEx);
            TransformerMock.Verify(transform => transform.Transform(null), Times.Once);
            TransformerMock.VerifyNoOtherCalls();
            TransformerMock.Reset();
        }

        [TestMethod]
        public void WrapsExceptionInTransformException()
        {
            TransformationException thrownEx = null;
            try
            {
                TransformerMock.Setup(transform => transform.Transform(null)).Throws(GeneralException);
                TransformationService.Transform(null);
            }
            catch (TransformationException tex)
            {
                thrownEx = tex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(TransformationException));
            Assert.AreEqual(GeneralException, thrownEx.InnerException);
            TransformerMock.Verify(transform => transform.Transform(null), Times.Once);
            TransformerMock.VerifyNoOtherCalls();
            TransformerMock.Reset();
        }

        [TestMethod]
        public void WrapsExceptionInTransformExceptionNullTransformer()
        {
            TransformationException thrownEx = null;
            try
            {
                new TransformationService<string, bool>(null).Transform(null);
            }
            catch (TransformationException tex)
            {
                thrownEx = tex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(TransformationException));
        }
    }
}
