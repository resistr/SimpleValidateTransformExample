using Framework.Async;
using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Derivation
{
    /// <summary>
    /// A <see cref="DerivationAttribute"/> that provides a custom derivation method 
    /// that is used to derive a property or class asynchronously.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public abstract class AsyncDerivationAttributeBase :DerivationAttribute
    {
        private string LastMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncDerivationAttributeBase" /> class.
        /// </summary>
        protected AsyncDerivationAttributeBase() : base(() => "{0} is not derivable.") { }

        /// <summary>
        /// Method to override that performs the asynchronous derivation.
        /// </summary>
        /// <param name="itemToDerive">The value of the object to derive.</param>
        /// <param name="derivationContext">The derivation context.</param>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be canceled.</param>
        /// <returns>A task representing the result of the derivation.</returns>
        protected abstract Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default);

        /// <summary>
        /// Does the derivation against the specified value of the object.
        /// </summary>
        /// <param name="value">The value of the object to derive.</param>
        /// <param name="derivationContext">The derivation context.</param>
        /// <returns>The result of the derivation.</returns>
        protected override DerivationResult DoDerivation(object value, DerivationContext derivationContext)
        {
            DerivationResult result = AsyncHelper.RunSync(() => DeriveInternal(value, derivationContext));

            LastMessage = null;

            if (result != null)
            {
                LastMessage = result.ErrorMessage;
            }

            return result;
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public override string FormatErrorMessage(string name)
        {
            string formatErrorMessage = null;
            if (!string.IsNullOrEmpty(LastMessage))
            {
                formatErrorMessage = String.Format(CultureInfo.CurrentCulture, LastMessage, name);
            }
            else
            {
                formatErrorMessage = base.FormatErrorMessage(name);
            }
            return formatErrorMessage;
        }

        /// <summary>
        /// A shortcut to provide <see cref="DerivationResult.Success"/>.
        /// </summary>
        protected virtual DerivationResult Success { get => DerivationResult.Success; }

        /// <summary>
        /// A shortcut to provide <see cref="DerivationResult"/> for derivation failure.
        /// </summary>
        protected virtual DerivationResult Failure { get => new DerivationResult(null); }

        /// <summary>
        /// A shortcut to provide <see cref="DerivationResult"/> for derivation failure with a custom message.
        /// </summary>
        /// <param name="message">The custom message of the failure.</param>
        /// <returns>The failure derivation result.</returns>
        protected virtual DerivationResult CreateFailure(string message) => new DerivationResult(message);
    }
}
