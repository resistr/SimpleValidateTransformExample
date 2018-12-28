using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Derivation
{
    /// <summary>
    /// An interface describing the common funcationality of 
    /// strongly typed derivations.
    /// </summary>
    /// <typeparam name="TSource">The source type of the derivation.</typeparam>
    /// <typeparam name="TDest">The destination type of the derivation.</typeparam>
    public interface IDerive<TSource, TDest>
    {
        /// <summary>
        ///  Does the actual derivation. 
        /// </summary>
        /// <param name="source">The source object to derive.</param>
        /// <param name="dest">The dest object to derive.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be cancelled.
        /// </param>
        /// <returns>A task representing the result of the derivation.</returns>
        /// <exception cref="DerivationException">Wraps any underlying exception that may have occured.</exception>
        Task<TDest> Derive(TSource source, TDest dest, CancellationToken cancellationToken = default);
    }
}
