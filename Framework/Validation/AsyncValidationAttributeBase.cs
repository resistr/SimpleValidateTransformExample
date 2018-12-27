using Framework.Async;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Validation
{
    /// <summary>
    /// A <see cref="ValidationAttribute"/> that provides a custom validation method 
    /// that is used to validate a property or class asynchronously.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public abstract class AsyncValidationAttributeBase : ValidationAttribute
    {
        private string LastMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncValidationAttributeBase" /> class.
        /// </summary>
        protected AsyncValidationAttributeBase() : base(() => "{0} is not valid.") { }

        /// <summary>
        /// Method to override that performs the asynchronous validation.
        /// </summary>
        /// <param name="itemToValidate">The value of the object to validate.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be canceled.</param>
        /// <returns>A task representing the result of the validation.</returns>
        protected abstract Task<ValidationResult> ValidateInternal(object itemToValidate, ValidationContext validationContext, CancellationToken cancellationToken = default);

        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>The result of the validation.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = AsyncHelper.RunSync(() => ValidateInternal(value, validationContext));

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
        /// A shortcut to provide <see cref="ValidationResult.Success"/>.
        /// </summary>
        protected virtual ValidationResult Success { get => ValidationResult.Success; }

        /// <summary>
        /// A shortcut to provide <see cref="ValidationResult"/> for validation failure.
        /// </summary>
        protected virtual ValidationResult Failure { get => new ValidationResult(null); }

        /// <summary>
        /// A shortcut to provide <see cref="ValidationResult"/> for validation failure with a custom message.
        /// </summary>
        /// <param name="message">The custom message of the failure.</param>
        /// <returns>The failure validation result.</returns>
        protected virtual ValidationResult CreateFailure(string message) => new ValidationResult(message);

    }
}
