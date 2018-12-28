using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.DataProvider
{
    /// <summary>
    /// An interface describing the functionality of a data provider.
    /// </summary>
    /// <typeparam name="T">The type of data the data provider provides.</typeparam>
    public interface IProvideData<T>
    {
        /// <summary>
        /// Gets a collection of all of the data provided by this provider. 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>A collection of all of the data the provider provides.</returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
