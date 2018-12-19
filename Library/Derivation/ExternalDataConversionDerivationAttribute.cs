using Framework;
using Framework.DataProvider;
using Framework.Derivation;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Derivation
{
    public class ExternalDataConversionDerivationAttribute : AsyncDerivationAttributeBase
    {

        protected readonly string Field;
        protected readonly Type KeyedDataProviderType;

        public ExternalDataConversionDerivationAttribute(string field, Type keyedDataProviderType) : base()
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field is required.", nameof(field));
            }
            Field = field;
            KeyedDataProviderType = keyedDataProviderType ?? throw new ArgumentNullException("Keyed data provider type is required.", nameof(keyedDataProviderType));
        }

        protected override async Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default)
        {

            var keyedDataProvider = derivationContext.GetService(KeyedDataProviderType) as IProvideKeyedData;
            var keyedData = await keyedDataProvider.ToReadOnlyDictionaryAsync(cancellationToken);

            if (!itemToDerive.TryGetProperty(Field, out PropertyInfo propertyInfo))
            {
                return Failure;
            }

            if (!itemToDerive.TryGetPropertyValue(propertyInfo, out object value))
            {
                return Failure;
            }

            if (!keyedData.ContainsKey(value))
            {
                return Failure;
            }

            if (!itemToDerive.TrySetPropertyValue(propertyInfo, keyedData[value]))
            {
                return Failure;
            }

            return Success;
        }
    }
}
