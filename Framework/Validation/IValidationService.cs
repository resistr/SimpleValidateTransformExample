using System.ComponentModel.DataAnnotations; // used by cref

namespace Framework.Validation
{
    /// <summary>
    /// An interface describing the ability to validate objects using <see cref="Validator"/>
    /// </summary>
    public interface IValidationService
    {
        /// <summary>
        /// Validate the item.
        /// </summary>
        /// <typeparam name="T">The type of the item to validate.</typeparam>
        /// <param name="source">The item to validate.</param>
        /// <returns>The unmodified item post validation.</returns>
        /// <exception cref="ValidationException">If any validation errors occur.</exception>
        T Validate<T>(T source);
    }
}
