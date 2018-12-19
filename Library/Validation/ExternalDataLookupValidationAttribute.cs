using Framework;
using Framework.DataProvider;
using Framework.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Validation
{
    public class ExternalDataLookupValidationAttribute : AsyncValidationAttributeBase
    {
        protected readonly string Field;
        protected readonly Type KeyedDataProviderType;

        public ExternalDataLookupValidationAttribute(string field, Type keyedDataProviderType) : base()
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                throw new ArgumentNullException("Field to validate is required.", nameof(field));
            }
            Field = field;
            KeyedDataProviderType = keyedDataProviderType ?? throw new ArgumentNullException("Keyed data provider type is required.", nameof(keyedDataProviderType));
        }

        protected override async Task<ValidationResult> ValidateInternal(object itemToValidate, ValidationContext validationContext, CancellationToken cancellationToken = default)
        {
            var keyedDataProvider = validationContext.GetService(KeyedDataProviderType) as IProvideKeyedData;
            var keyedData = await keyedDataProvider.ToReadOnlyDictionaryAsync(cancellationToken);

            if (itemToValidate.TryGetPropertyValue(Field, out object value) && keyedData.ContainsKey(value))
            {
                return Success;
            }
            return Failure;
        }
    }
}
