using System.Collections.Generic;

namespace Framework.Derivation
{
    /// <summary>
    /// Provides a way for an object to be derived.
    /// </summary>
    public interface IDerivableObject
    {
        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="derivationContext">The derivation context.</param>
        /// <returns>A collection that holds failed-derivation information.</returns>
        IEnumerable<DerivationResult> Derive(DerivationContext derivationContext);
    }
}
