using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.Framework.Tests.Transformation
{
    [TestClass]
    public class TransformerBaseTests
    {
        protected readonly Exception GeneralException = new Exception();
        protected readonly TransformationException TransformationException = new TransformationException();

        [TestMethod]
        public void CallsTransformInternal()
            => Assert.IsTrue(new TestTransformer<string, bool>(bool.Parse).Transform(bool.TrueString));

        [TestMethod]
        public void RethrowsTransformException()
        {
            TransformationException thrownEx = null;
            try
            {
                new TestTransformer<string, bool>(str => { throw TransformationException; }).Transform(bool.TrueString);
            }
            catch (TransformationException tex)
            {
                thrownEx = tex;
            }

            Assert.AreEqual(TransformationException, thrownEx);
        }

        [TestMethod]
        public void WrapsExceptionInTransformException()
        {
            TransformationException thrownEx = null;
            try
            {
                new TestTransformer<string, bool>(str => { throw GeneralException; }).Transform(bool.TrueString);
            }
            catch (TransformationException tex)
            {
                thrownEx = tex;
            }
            Assert.IsInstanceOfType(thrownEx, typeof(TransformationException));
            Assert.AreEqual(GeneralException, thrownEx.InnerException);
        }
    }
}
