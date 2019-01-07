using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Caching
{
    /// <summary>
    /// An interface defining common functionality for interacting with the types stored in 
    /// <see cref="Microsoft.Extensions.Caching.Memory.IMemoryCache"/>.
    /// </summary>
    /// <typeparam name="T">The type of item(s) to get or add to the cache.</typeparam>
    public interface ICachedTypeProvider<T>
    {
        /// <summary>
        /// Gets the requested type of item(s) from the memory cache. If unavailable;
        /// Runs the provided function to obtain the items and caches them.
        /// </summary>
        /// <param name="func">The delegate to call to retrieve the data if not available in the cache.</param>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The item(s) from the cache.</returns>
        Task<T> GetOrCreateAsync(
            Func<CancellationToken, Task<T>> func,
            CancellationToken cancellationToken = default);
    }
}
