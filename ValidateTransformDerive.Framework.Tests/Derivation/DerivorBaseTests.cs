using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Derivation
{
    [TestClass]
    public class DerivorBaseTests
    {
        protected readonly Exception GeneralException = new Exception();
        protected readonly DerivationException DerivationException = new DerivationException();

        [TestMethod]
        public async Task CallsDeriveInternal()
            => Assert.IsTrue(await new TestDerivor<string, bool>((s, b) => bool.Parse(s)).Derive(bool.TrueString, false));

        [TestMethod]
        public async Task RethrowsDerivationException()
        {
            DerivationException thrownEx = null;
            try
            {
                await new TestDerivor<string, bool>((s, b) => { throw DerivationException; }).Derive(bool.TrueString, false);
            }
            catch (DerivationException dex)
            {
                thrownEx = dex;
            }

            Assert.AreEqual(DerivationException, thrownEx);
        }

        [TestMethod]
        public async Task WrapsExceptionInDerivationException()
        {
            DerivationException thrownEx = null;
            try
            {
                await new TestDerivor<string, bool>((s, b) => { throw GeneralException; }).Derive(bool.TrueString, false);
            }
            catch (DerivationException dex)
            {
                thrownEx = dex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(DerivationException));
            Assert.AreEqual(GeneralException, thrownEx.InnerException);
        }
    }
}
