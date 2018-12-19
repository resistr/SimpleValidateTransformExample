using Framework;
using Framework.Derivation;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Derivation
{
    public class DataCalculationDerivationAttribute : AsyncDerivationAttributeBase
    {
        public string SourceFieldName { get; protected set; }
        public string FieldNameToAdd { get; protected set; }
        public string DestFieldName { get; protected set; }

        public DataCalculationDerivationAttribute(string sourceFieldName, string fieldNameToAdd, string destFieldName) : base()
        {
            if (string.IsNullOrWhiteSpace(sourceFieldName))
            {
                throw new ArgumentNullException($"{nameof(sourceFieldName)} is required.", nameof(sourceFieldName));
            }
            if (string.IsNullOrWhiteSpace(fieldNameToAdd))
            {
                throw new ArgumentNullException($"{nameof(fieldNameToAdd)} is required.", nameof(fieldNameToAdd));
            }
            if (string.IsNullOrWhiteSpace(destFieldName))
            {
                throw new ArgumentNullException($"{nameof(destFieldName)} is required.", nameof(destFieldName));
            }
            SourceFieldName = sourceFieldName;
            FieldNameToAdd = fieldNameToAdd;
            DestFieldName = destFieldName;
        }

        protected override Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default)
        {
            if (!itemToDerive.TryGetProperty(DestFieldName, out PropertyInfo destPropertyInfo))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TryGetPropertyValue(SourceFieldName, out object sourceValue))
            {
                return Task.FromResult(Failure);
            }

            if (!sourceValue.TryChangeType(out int sourceIntValue))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TryGetPropertyValue(FieldNameToAdd, out object fieldNameToAddValue))
            {
                return Task.FromResult(Failure);
            }

            if (!fieldNameToAddValue.TryChangeType(out int fieldNameToAddIntValue))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TrySetPropertyValue(destPropertyInfo, sourceIntValue + fieldNameToAddIntValue))
            {
                return Task.FromResult(Failure);
            }

            return Task.FromResult(Success);
        }
    }
}
