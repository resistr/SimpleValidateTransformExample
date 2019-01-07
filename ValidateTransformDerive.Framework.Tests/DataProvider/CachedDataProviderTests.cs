using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Caching;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Tests.DataProvider
{
    [TestClass]
    public class CachedDataProviderTests
    {
        protected readonly Mock<IProvideData<string>> DataProviderMock = new Mock<IProvideData<string>>();
        protected readonly Mock<ICachedTypeProvider<IEnumerable<string>>> CachedTypeProviderMock 
            = new Mock<ICachedTypeProvider<IEnumerable<string>>>();
        protected readonly CachedDataProvider<string> Provider;

        public CachedDataProviderTests()
            => Provider = new CachedDataProvider<string>(DataProviderMock.Object, CachedTypeProviderMock.Object);

        [TestMethod]
        public async Task GetAllAsyncCallsGetOrCreateAsyncAndDataProviderGetAllAsync()
        {
            Setup();

            await Provider.GetAllAsync();

            VerifySetupOnce();
            VerifyNoOtherCalls();
            Reset();
        }

        [TestMethod]
        public async Task StartupCallsGetOrCreateAsyncAndDataProviderGetAllAsync()
        {
            Setup();

            await Provider.Startup();

            VerifySetupOnce();
            VerifyNoOtherCalls();
            Reset();
        }

        private void Setup()
        {
            CachedTypeProviderMock.Setup(cacheProvider => cacheProvider.GetOrCreateAsync(
                It.IsAny<Func<CancellationToken, Task<IEnumerable<string>>>>(),
                It.IsAny<CancellationToken>())
            ).Returns<Func<CancellationToken, Task<IEnumerable<string>>>, CancellationToken>((func, token) => func(token));
        }

        private void VerifySetupOnce()
        {
            CachedTypeProviderMock.Verify(cacheProvider => cacheProvider.GetOrCreateAsync(
                It.IsAny<Func<CancellationToken, Task<IEnumerable<string>>>>(),
                It.IsAny<CancellationToken>()),
            Times.Once);

            DataProviderMock.Verify(dataProvider => dataProvider.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        private void VerifyNoOtherCalls()
        {
            CachedTypeProviderMock.VerifyNoOtherCalls();
            DataProviderMock.VerifyNoOtherCalls();
        }

        private void Reset()
        {
            CachedTypeProviderMock.Reset();
            DataProviderMock.Reset();
        }
    }
}
