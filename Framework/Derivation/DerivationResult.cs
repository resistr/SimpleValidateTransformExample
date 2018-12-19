using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Derivation
{
    public class DerivationResult
    {
        public static readonly DerivationResult Success;

        public DerivationResult(string errorMessage)
            : this(errorMessage, null)
        {
        }

        public DerivationResult(string errorMessage, IEnumerable<string> memberNames)
        {
            ErrorMessage = errorMessage;
            MemberNames = memberNames ?? Enumerable.Empty<string>();
        }

        protected DerivationResult(DerivationResult DerivationResult)
        {
            if (DerivationResult == null)
            {
                throw new ArgumentNullException(nameof(DerivationResult));
            }

            ErrorMessage = DerivationResult.ErrorMessage;
            MemberNames = DerivationResult.MemberNames;
        }

        public IEnumerable<string> MemberNames { get; private set; }

        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return ErrorMessage ?? base.ToString();
        }
    }
}
