using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Common
{
    /// <summary>
    /// Common extensions for <see cref="IEnumerable{T}"/>.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Verifies if a single item exists in the collection and throws the 
        /// correct custom exception if not.
        /// </summary>
        /// <typeparam name="T">The type of the collection.</typeparam>
        /// <param name="items">The collection of items to verify.</param>
        /// <param name="none">The delegate coresponding to the exception to throw if no items are in the collection or if the collection is null.</param>
        /// <param name="many">The delegate coresponding to the exception to throw if more than one item is in the collection.</param>
        /// <returns>The single item from the collection.</returns>
        public static T VerifyOne<T>(this IEnumerable<T> items, Func<Exception> none, Func<Exception> many)
        {
            var count = items?.Count();
            if (!count.HasValue || count < 1)
            {
                throw none();
            }
            if (count > 1)
            {
                throw many();
            }
            return items.Single();
        }
    }
}
