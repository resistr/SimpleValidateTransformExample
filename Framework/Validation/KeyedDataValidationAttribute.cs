using Framework.DataProvider;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Validation
{
    /// <summary>
    /// Custom validation attribute to validate a value against keyed data.
    /// </summary>
    public class KeyedDataValidationAttribute : AsyncValidationAttributeBase
    {
        protected readonly Type IProvideKeyedDataType = typeof(IProvideKeyedData);
        protected readonly Type KeyedDataProviderType;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyedDataValidationAttribute"/> class.
        /// </summary>
        /// <param name="keyedDataProviderType">The type of the <see cref="IProvideKeyedData"/> data provider to use for validation.</param>
        /// <exception cref="ArgumentNullException">If keyedDataProviderType is not provided.</exception>
        /// <exception cref="ArgumentException">If keyedDataProviderType is not assignable from <see cref="IProvideKeyedData"/>.</exception>
        public KeyedDataValidationAttribute(Type keyedDataProviderType) : base()
        {
            KeyedDataProviderType = keyedDataProviderType 
                ?? throw new ArgumentNullException("Keyed data provider type is required.", nameof(keyedDataProviderType));

            if(!IProvideKeyedDataType.IsAssignableFrom(KeyedDataProviderType))
            {
                throw new ArgumentException($"Keyed data provider type myst be assignable from {nameof(IProvideKeyedData)}.", nameof(keyedDataProviderType));
            }
        }

        protected override async Task<ValidationResult> ValidateInternal(object itemToValidate, ValidationContext validationContext, CancellationToken cancellationToken = default)
        {
            var keyedDataProvider = validationContext.GetService(KeyedDataProviderType) as IProvideKeyedData;
            if (keyedDataProvider == null)
            {
                throw new NullReferenceException($"Unable to get keyed data provider of type {KeyedDataProviderType?.Name ?? "{null}"} from service provider.");
            }

            var keyedData = await keyedDataProvider.GetReadOnlyDictionaryAsync(cancellationToken);

            return keyedData.ContainsKey(itemToValidate) ? Success : Failure;
        }
    }
}
