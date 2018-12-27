using System.Threading;
using System.Threading.Tasks;

namespace Framework.Common
{
    /// <summary>
    /// Interface describing common functionality for having an action occur at startup. 
    /// </summary>
    public interface IHaveStartupActions
    {
        /// <summary>
        /// The action to take at application startup. 
        /// </summary>
        /// <param name="cancellationToken">The token used to determine if the asynchronous operation should cancel.</param>
        /// <returns>A task representing the work being done at startup.</returns>
        Task Startup(CancellationToken cancellationToken = default);
    }
}
