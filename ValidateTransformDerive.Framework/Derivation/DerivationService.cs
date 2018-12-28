using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Derivation
{
    /// <summary>
    /// A strongly typed derivation service. 
    /// </summary>
    /// <typeparam name="TSource">The source type of the derivation.</typeparam>
    /// <typeparam name="TDest">The destination type of the derivation.</typeparam>
    public class DerivationService<TSource, TDest> : IDerivationService<TSource, TDest>
    {
        protected readonly IDerive<TSource, TDest> Derivor;

        /// <summary>
        ///  Initializes a new instance of the <see cref="DerivationService{TSource, TDest}"/> class.
        /// </summary>
        /// <param name="derivor">The derivor for the types derived by this service.</param>
        public DerivationService(IDerive<TSource, TDest> derivor)
            => Derivor = derivor;

        /// <summary>
        /// Does the actual derivation. 
        /// </summary>
        /// <param name="source">The source object to derive.</param>
        /// <param name="dest">The dest object to derive.</param>
        /// <param name="cancellationToken">
        /// The cancellation token used to determine if the asynchronous operation should be cancelled.
        /// </param>
        /// <returns>A task representing the result of the derivation.</returns>
        /// <exception cref="DerivationException">Wraps any underlying exception that may have occured.</exception>
        public async Task<TDest> Derive(TSource source, TDest dest, CancellationToken cancellationToken = default)
        {
            try
            {
                // do the derivation and return the result
                return await Derivor.Derive(source, dest, cancellationToken);
            }
            catch (DerivationException) { throw; } // no need to wrap a derivation exception
            catch (Exception ex)
            {
                // failure; wrap the exception in a derivation exception
                throw new DerivationException("Error running derivation.", Derivor?.GetType(), source, dest, ex);
            }
        }
    }
}
