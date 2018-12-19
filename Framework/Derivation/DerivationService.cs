using System;
using System.Collections.Generic;

namespace Framework.Derivation
{
    public class DerivationService : IDerivationService
    {
        protected readonly IServiceProvider ServiceProvider;

        public DerivationService(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public T Derive<T>(T source)
        {
            var success = false;
            var derivationResults = new List<DerivationResult>();
            try
            {
                success = Derivor.TryDeriveObject(source, new DerivationContext(source, ServiceProvider, null), derivationResults);
            }
            catch (Exception ex)
            {
                throw new DerivationException("Error running derivations.", ex);
            }
            if (!success)
            {
                throw new DerivationException("Error running derivations.", derivationResults, source);
            }
            return source;
        }
    }
}
