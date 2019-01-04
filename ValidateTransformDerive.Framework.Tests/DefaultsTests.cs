using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ValidateTransformDerive.Framework.Tests
{
    [TestClass]
    public class DefaultsTests
    {
        protected static readonly int x = default;
        protected static readonly Type IntType = typeof(int);

        [TestMethod]
        public void DefaultsTest()
            => Assert.AreEqual(x, Defaults.Default(IntType));

        [TestMethod]
        public void DefaultsGenericTest()
            => Assert.AreEqual(x, Defaults.Default<int>());
    }
}
