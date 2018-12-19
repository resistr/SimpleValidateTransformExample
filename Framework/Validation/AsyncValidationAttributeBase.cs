using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Validation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public abstract class AsyncValidationAttributeBase : ValidationAttribute
    {
        private string LastMessage;

        protected AsyncValidationAttributeBase() : base(() => "{0} is not valid.") { }

        protected abstract Task<ValidationResult> ValidateInternal(object itemToValidate, ValidationContext validationContext, CancellationToken cancellationToken = default);

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

        protected virtual ValidationResult Success { get => ValidationResult.Success; }

        protected virtual ValidationResult Failure { get => new ValidationResult(null); }

    }
}
