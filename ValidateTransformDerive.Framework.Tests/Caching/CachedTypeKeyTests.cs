using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateTransformDerive.Framework.Caching;

namespace ValidateTransformDerive.Framework.Tests.Caching
{
    [TestClass]
    public class CachedTypeKeyTests
    {
        [TestMethod]
        public void CacheKeyInstanceIsSame()
            => Assert.AreEqual(CachedTypeKey<object>.Instance, CachedTypeKey<object>.Instance);

        [TestMethod]
        public void CacheKeyInstanceIsDifferent()
            => Assert.AreNotEqual(CachedTypeKey<object>.Instance, CachedTypeKey<CachedTypeKeyTests>.Instance);
    }
}
