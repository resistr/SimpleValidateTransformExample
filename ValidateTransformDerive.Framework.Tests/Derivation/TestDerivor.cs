using System;
using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Derivation;

namespace ValidateTransformDerive.Framework.Tests.Derivation
{
    public class TestDerivor<TSource, TDest> : DerivorBase<TSource, TDest>
    {
        protected readonly Func<TSource, TDest, TDest> DeriveFunc;

        public TestDerivor(Func<TSource, TDest, TDest> func)
            => DeriveFunc = func;

        public override Task<TDest> DeriveInternal(TSource source, TDest dest, CancellationToken cancellationToken = default)
            => Task.FromResult(DeriveFunc(source, dest));
    }
}
