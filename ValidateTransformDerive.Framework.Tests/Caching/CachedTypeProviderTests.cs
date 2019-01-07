using Moq;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidateTransformDerive.Framework.Caching;
using System;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Caching.Options;

namespace ValidateTransformDerive.Framework.Tests.DataProvider
{
    [TestClass]
    public class CachedTypeProviderTests
    {
        protected readonly Mock<ICacheEntry> CacheEntryMock = new Mock<ICacheEntry>();
        protected readonly Mock<IMemoryCache> MemoryCacheMock = new Mock<IMemoryCache>();
        protected readonly Mock<ICachedTypeOptionsProvider> OptionsProvider = new Mock<ICachedTypeOptionsProvider>();
        protected readonly CachedTypeProvider<string> Provider;
        protected readonly DateTimeOffset AbsoluteExpiration = new DateTimeOffset(new DateTime(9999, 12,31));
        protected readonly TimeSpan AbsoluteExpirationRelative = new TimeSpan(1, 2, 3);
        protected readonly TimeSpan SlidingExpiration = new TimeSpan(4, 5, 6);
        protected readonly MemoryCacheEntryOptions MemoryCacheEntryOptions;
        protected object CacheEntry = nameof(CachedTypeProviderTests);
        protected object CacheKey = CachedTypeKey<string>.Instance;

        public CachedTypeProviderTests()
        {
            Provider = new CachedTypeProvider<string>(MemoryCacheMock.Object, OptionsProvider.Object);

            MemoryCacheEntryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = AbsoluteExpiration,
                AbsoluteExpirationRelativeToNow = AbsoluteExpirationRelative,
                SlidingExpiration = SlidingExpiration
            };
        }

        [TestMethod]
        public async Task UsesExpectedCacheKey()
        {
            // get the value from the cache
            SetupMock(true);

            var cacheResult = await Provider.GetOrCreateAsync((token) => Task.FromResult(string.Empty));

            Assert.AreEqual(CacheEntry, cacheResult);
            MemoryCacheMock.Verify(cache => cache.TryGetValue(CacheKey, out CacheEntry), Times.Once);

            VerifyNoOtherCalls();
            Reset();
        }

        [TestMethod]
        public async Task CacheEntryValueInstanceOfTypeReturns()
        {
            // fail to get the value from the cache
            SetupMock(false);

            var cacheResult = await Provider.GetOrCreateAsync((token) => Task.FromResult(string.Empty));

            //we got the righ value back from the cache
            Assert.AreEqual(string.Empty, cacheResult);

            // tried to get the value from the cache
            MemoryCacheMock.Verify(cache => cache.TryGetValue(CacheKey, out CacheEntry), Times.Once);

            // created an entry for the key
            MemoryCacheMock.Verify(cache => cache.CreateEntry(CacheKey), Times.Once);

            // set the proper options to the entry
            CacheEntryMock.VerifySet(entry => entry.AbsoluteExpiration = MemoryCacheEntryOptions.AbsoluteExpiration, Times.Once);
            CacheEntryMock.VerifySet(entry => 
                entry.AbsoluteExpirationRelativeToNow = MemoryCacheEntryOptions.AbsoluteExpirationRelativeToNow, Times.Once);
            CacheEntryMock.VerifySet(entry => entry.SlidingExpiration = MemoryCacheEntryOptions.SlidingExpiration, Times.Once);
            CacheEntryMock.VerifySet(entry => entry.Priority = MemoryCacheEntryOptions.Priority, Times.Once);
            CacheEntryMock.VerifySet(entry => entry.Size = MemoryCacheEntryOptions.Size, Times.Once);

            // set the proper value to the entry
            CacheEntryMock.VerifySet(entry => entry.Value = string.Empty, Times.Once);

            // called dispose on the entry
            CacheEntryMock.Verify(entry => entry.Dispose());

            // requested the proper options from the options provider; no other calls
            OptionsProvider.Verify(provider => provider.GetCacheEntryOption(typeof(string).FullName), Times.Once);

            // no other calls
            VerifyNoOtherCalls();

            // reset
            Reset();
        }

        private void SetupMock(bool getFromCache)
        {
            // setup the cache
            MemoryCacheMock.Setup(cache => cache.TryGetValue(CacheKey, out CacheEntry)).Returns(getFromCache);

            // return a cache entry
            MemoryCacheMock.Setup(cache => cache.CreateEntry(CacheKey)).Returns(CacheEntryMock.Object);

            // return options
            OptionsProvider.Setup(provider => provider.GetCacheEntryOption(typeof(string).FullName))
                .Returns(new CachedTypeOption
                {
                    MemoryCacheEntryOptions = MemoryCacheEntryOptions
                });
        }

        private void Reset()
        {
            MemoryCacheMock.Reset();
            CacheEntryMock.Reset();
            OptionsProvider.Reset();
        }

        private void VerifyNoOtherCalls()
        {
            MemoryCacheMock.VerifyNoOtherCalls();
            CacheEntryMock.VerifyNoOtherCalls();
            OptionsProvider.VerifyNoOtherCalls();
        }
    }
}
