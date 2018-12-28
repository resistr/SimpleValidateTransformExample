using System;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Derivation
{
    /// <summary>
    /// A base class to provide common functionality to derivation classes.
    /// </summary>
    /// <typeparam name="TSource">The source type of the derivation.</typeparam>
    /// <typeparam name="TDest">The destination type of the derivation.</typeparam>
    public abstract class DerivorBase<TSource, TDest> : IDerive<TSource, TDest>
    {
        protected Type DerivorType;

        protected DerivorBase() => DerivorType = GetType();

        /// <summary>
        ///  Does the actual derivation. 
        /// </summary>
        /// <param name="source">The source object to derive.</param>
        /// <param name="source">The dest object to derive.</param>
        /// <returns>The result of the derivation.</returns>
        public abstract Task<TDest> DeriveInternal(TSource source, TDest dest, CancellationToken cancellationToken = default);

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
        public async Task<TDest> Derive(TSource source, TDest dest, CancellationToken cancellationToken = default)
        {
            try
            {
                // do the derivation and return the result
                return await DeriveInternal(source, dest, cancellationToken);
            }
            catch (DerivationException) { throw; } // no need to wrap a derivation exception
            catch (Exception ex)
            {
                // some unknown error occured in the derivation process; wrap it in a DerivationException
                // likely a derivation had an uncaught exception
                throw new DerivationException("Error deriving.", DerivorType, source, dest, ex);
            }
        }
    }
}
