using System;
using System.Collections.Generic;

namespace Framework.Derivation
{
    /// <summary>
    /// A sewrvice providing the ability to derive objects using <see cref="Derivor"/>
    /// </summary>
    public class DerivationService : IDerivationService
    {
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationService class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to provide to the <see cref="DerivationContext"/>.</param>
        public DerivationService(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        /// <summary>
        /// Derive the item.
        /// </summary>
        /// <typeparam name="T">The type of the item to derive.</typeparam>
        /// <param name="source">The item to derive.</param>
        /// <returns>The modified item post derivation.</returns>
        /// <exception cref="DerivationException">If any derivation errors occur.</exception>
        public T Derive<T>(T source)
        {
            var success = false;
            var derivationResults = new List<DerivationResult>();
            try
            {
                success = Derivor.TryDeriveObject(source, new DerivationContext(source, ServiceProvider, null), derivationResults);
            }
            catch (Exception ex)
            {
                throw new DerivationException("Error running derivations.", ex);
            }
            if (!success)
            {
                throw new DerivationException("Error running derivations.", derivationResults, source);
            }
            return source;
        }
    }
}
