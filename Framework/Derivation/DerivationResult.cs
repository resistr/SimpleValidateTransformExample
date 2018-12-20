using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Derivation
{
    /// <summary>
    /// Represents a container for the results of a derivation request.
    /// </summary>
    public class DerivationResult
    {
        /// <summary>
        /// Represents the success of the derivation (true if derivation was successful;
        /// otherwise, false).
        /// </summary>
        public static readonly DerivationResult Success;

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationResult
        /// class by using an error message.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public DerivationResult(string errorMessage)
            : this(errorMessage, null) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationResult
        /// class by using an error message and a list of members that have validation errors.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        /// <param name="memberNames">The list of member names that have validation errors.</param>
        public DerivationResult(string errorMessage, IEnumerable<string> memberNames)
        {
            ErrorMessage = errorMessage;
            MemberNames = memberNames ?? Enumerable.Empty<string>();
        }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationResult
        /// class by using a Framework.Derivation.DerivationResult object.
        /// </summary>
        /// <param name="DerivationResult">The derivation result object.</param>
        /// <exception cref="ArgumentNullException">If derivation result is not provided.</exception>
        protected DerivationResult(DerivationResult DerivationResult)
        {
            if (DerivationResult == null)
            {
                throw new ArgumentNullException(nameof(DerivationResult));
            }

            ErrorMessage = DerivationResult.ErrorMessage;
            MemberNames = DerivationResult.MemberNames;
        }

        /// <summary>
        /// Gets the collection of member names that indicate which fields have derivation
        /// errors.
        /// </summary>
        public IEnumerable<string> MemberNames { get; private set; }

        /// <summary>
        /// Gets the error message for the derivation.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Returns a string representation of the current derivation result.
        /// </summary>
        /// <returns>The current derivation result</returns>
        public override string ToString()
        {
            return ErrorMessage ?? base.ToString();
        }
    }
}
