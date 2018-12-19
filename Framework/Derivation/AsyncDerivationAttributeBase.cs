using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Derivation
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public abstract class AsyncDerivationAttributeBase :DerivationAttribute
    {
        private string LastMessage;

        protected AsyncDerivationAttributeBase() : base(() => "{0} is not derivable.") { }

        protected abstract Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default);

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

        protected virtual DerivationResult Success { get => DerivationResult.Success; }

        protected virtual DerivationResult Failure { get => new DerivationResult(null); }

    }
}
