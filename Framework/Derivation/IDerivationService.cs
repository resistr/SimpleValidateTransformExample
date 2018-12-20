namespace Framework.Derivation
{
    /// <summary>
    /// An interface describing the ability to derive objects using <see cref="Derivor"/>
    /// </summary>
    public interface IDerivationService
    {
        /// <summary>
        /// Derive the item.
        /// </summary>
        /// <typeparam name="T">The type of the item to derive.</typeparam>
        /// <param name="source">The item to derive.</param>
        /// <returns>The modified item post derivation.</returns>
        /// <exception cref="DerivationException">If any derivation errors occur.</exception>
        T Derive<T>(T source);
    }
}
