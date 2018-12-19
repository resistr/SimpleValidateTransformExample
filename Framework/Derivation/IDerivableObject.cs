using System.Collections.Generic;

namespace Framework.Derivation
{
    public interface IDerivableObject
    {
        IEnumerable<DerivationResult> Derive(DerivationContext derivationContext);
    }
}
