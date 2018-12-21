using Framework.DataProvider;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Derivation
{
    /// <summary>
    /// Custom derivation attribute to derive a value from keyed data.
    /// </summary>
    public class KeyedDataDerivationAttribute : AsyncDerivationAttributeBase
    {
        protected readonly Type IProvideKeyedDataType = typeof(IProvideKeyedData);
        protected readonly string PropertyName;
        protected readonly Type KeyedDataProviderType;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedDataDerivationAttribute"/> class.
        /// </summary>
        /// <param name="propertyName">The name of the property in the item to derive to use.</param>
        /// <param name="keyedDataProviderType">The type of the <see cref="IProvideKeyedData"/> data provider to use for validation.</param>
        /// <exception cref="ArgumentNullException">If keyedDataProviderType or propertyName is not provided.</exception>
        /// <exception cref="ArgumentException">If keyedDataProviderType is not assignable from <see cref="IProvideKeyedData"/>.</exception>
        public KeyedDataDerivationAttribute(string propertyName, Type keyedDataProviderType) : base()
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentNullException("Property name is required.", nameof(propertyName));
            }
            PropertyName = propertyName;
            KeyedDataProviderType = keyedDataProviderType
                ?? throw new ArgumentNullException("Keyed data provider type is required.", nameof(keyedDataProviderType));

            if (!IProvideKeyedDataType.IsAssignableFrom(KeyedDataProviderType))
            {
                throw new ArgumentException($"Keyed data provider type myst be assignable from {nameof(IProvideKeyedData)}.", nameof(keyedDataProviderType));
            }
        }

        protected override async Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default)
        {

            var keyedDataProvider = derivationContext.GetService(KeyedDataProviderType) as IProvideKeyedData;
            var keyedData = await keyedDataProvider.GetReadOnlyDictionaryAsync(cancellationToken);

            if (!itemToDerive.TryGetProperty(PropertyName, out PropertyInfo propertyInfo))
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

            if (!itemToDerive.TrySetPropertyValue(propertyInfo, keyedData[value].GetValue()))
            {
                return Failure;
            }

            return Success;
        }
    }
}
