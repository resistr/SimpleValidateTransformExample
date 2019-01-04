using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Tests
{
    [TestClass]
    public class AsyncHelperTests
    {
        [TestMethod]
        public void RunSyncTests()
        {
            var ran = false;
            AsyncHelper.RunSync(() =>
            {
                System.Threading.Thread.Sleep(10);
                ran = true;
                return Task.CompletedTask;
            });
            Assert.IsTrue(ran);
        }

        [TestMethod]
        public void RunSyncTResultTests()
        {
            var ran = false;
            ran = AsyncHelper.RunSync(() =>
            {
                System.Threading.Thread.Sleep(10);
                return Task.FromResult(true);
            });
            Assert.IsTrue(ran);
        }

    }
}
