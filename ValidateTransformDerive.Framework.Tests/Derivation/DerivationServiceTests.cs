using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Derivation
{
    [TestClass]
    public class DerivationServiceTests
    {
        protected readonly Exception GeneralException = new Exception();
        protected readonly DerivationException DerivationException = new DerivationException();
        protected readonly Mock<IDerive<string, bool>> DerivorMock = new Mock<IDerive<string, bool>>();
        protected readonly DerivationService<string, bool> DerivationService;

        public DerivationServiceTests()
        {
            DerivationService = new DerivationService<string, bool>(DerivorMock.Object);
        }

        [TestMethod]
        public async Task CallsTransformInternal()
        {
            await DerivationService.Derive(null, false);
            DerivorMock.Verify(derivor => derivor.Derive(null, false, It.IsAny<CancellationToken>()), Times.Once);
            DerivorMock.VerifyNoOtherCalls();
            DerivorMock.Reset();
        }

        [TestMethod]
        public async Task RethrowsTransformException()
        {
            DerivationException thrownEx = null;
            try
            {
                DerivorMock.Setup(transform => transform.Derive(null, false, It.IsAny<CancellationToken>()))
                    .Throws(DerivationException);
                await DerivationService.Derive(null, false);
            }
            catch (DerivationException dex)
            {
                thrownEx = dex;
            }
            Assert.AreEqual(DerivationException, thrownEx);
            DerivorMock.Verify(transform => transform.Derive(null, false, It.IsAny<CancellationToken>()), Times.Once);
            DerivorMock.VerifyNoOtherCalls();
            DerivorMock.Reset();
        }

        [TestMethod]
        public async Task WrapsExceptionInTransformException()
        {
            DerivationException thrownEx = null;
            try
            {
                DerivorMock.Setup(transform => transform.Derive(null, false, It.IsAny<CancellationToken>()))
                    .Throws(GeneralException);
                await DerivationService.Derive(null, false);
            }
            catch (DerivationException dex)
            {
                thrownEx = dex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(DerivationException));
            Assert.AreEqual(GeneralException, thrownEx.InnerException);
            DerivorMock.Verify(transform => transform.Derive(null, false, It.IsAny<CancellationToken>()), Times.Once);
            DerivorMock.VerifyNoOtherCalls();
            DerivorMock.Reset();
        }

        [TestMethod]
        public async Task WrapsExceptionInTransformExceptionNullTransformer()
        {
            DerivationException thrownEx = null;
            try
            {
                await new DerivationService<string, bool>(null).Derive(null, false);
            }
            catch (DerivationException dex)
            {
                thrownEx = dex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(DerivationException));
        }
    }
}
