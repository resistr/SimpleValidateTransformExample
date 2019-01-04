using System.Threading;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.ImplementationSpecific.DataModel;
using ValidateTransformDerive.ImplementationSpecific.Dto;

namespace ValidateTransformDerive.ImplementationSpecific.Transform
{
    /// <summary>
    /// Specific implementation of <see cref="IDerive{SourceExample, DestExample}"/>.
    /// </summary>
    public class SourceExampleToDestExampleDerivation : DerivorBase<SourceExample, DestExample>
    {
        /// <summary>
        /// The DI provided <see cref="IProvideKeyedData{TKey, TValue}"/> keyed data provider.
        /// </summary>
        protected readonly IProvideKeyValueData<YesNoLookupData, string, string> KeyedDataProvider;

        public SourceExampleToDestExampleDerivation(IProvideKeyValueData<YesNoLookupData, string, string> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        /// <summary>
        /// Transforms <see cref="SourceExample"/> to <see cref="DestExample"/>.
        /// </summary>
        /// <param name="source">The source item to transform.</param>
        /// <returns>The transformed item.</returns>
        public override async Task<DestExample> DeriveInternal(SourceExample source, DestExample dest, CancellationToken cancellationToken = default)
        {
            // calculation 
            dest.TestDeriveAddedValue = dest.TestInt16 + dest.TestInt32;

            // external data
            dest.TestDeriveStringToBool = (await KeyedDataProvider.GetTypedReadOnlyDictionaryAsync())[source.TestString];

            // done
            return dest;
        }
    }
}
