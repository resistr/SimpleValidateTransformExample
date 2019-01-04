using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ValidateTransformDerive.Framework.Tests
{
    public static class MockExtensions
    {
        public static Mock<T> CreateMock<T>(this ICollection<Mock<T>> collection, Func<Mock<T>> func)
            where T : class
        {
            var mock = func();
            collection.Add(mock);
            return mock;
        }

        public static void Reset<T>(this ICollection<Mock<T>> collection)
            where T : class
            => collection.All(item => item.Reset());

        public static void VerifyNoOtherCalls<T>(this ICollection<Mock<T>> collection)
            where T : class
            => collection.All(item => item.VerifyNoOtherCalls());

        public static IEnumerable<T> ToObjects<T>(this IEnumerable<Mock<T>> collection)
            where T : class
            => collection.Select(item => item.Object);

        public static void All<T>(this IEnumerable<Mock<T>> collection, Action<Mock<T>> action)
            where T : class
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

    }
}
