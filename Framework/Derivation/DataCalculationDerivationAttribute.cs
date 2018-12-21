using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Derivation
{
    /// <summary>
    /// A custom derivation attribute that simply adds values from properties into a new property.
    /// </summary>
    public class DataCalculationDerivationAttribute : AsyncDerivationAttributeBase
    {
        public string SourcePropertyName { get; protected set; }
        public string PropertyNameToAdd { get; protected set; }
        public string DestPropertyName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataCalculationDerivationAttribute"/> class.
        /// </summary>
        /// <param name="sourcePropertyName">The property name of the source data.</param>
        /// <param name="propertyNameToAdd">The property name of the data to add.</param>
        /// <param name="destPropertyName">The property name to set the result to.</param>
        /// <exception cref="ArgumentNullException">If any property names are not provided.</exception>
        public DataCalculationDerivationAttribute(string sourcePropertyName, string propertyNameToAdd, string destPropertyName) : base()
        {
            if (string.IsNullOrWhiteSpace(sourcePropertyName))
            {
                throw new ArgumentNullException("Source property name is required.", nameof(sourcePropertyName));
            }
            if (string.IsNullOrWhiteSpace(propertyNameToAdd))
            {
                throw new ArgumentNullException("Property name to add is required.", nameof(propertyNameToAdd));
            }
            if (string.IsNullOrWhiteSpace(destPropertyName))
            {
                throw new ArgumentNullException("Dest property name is required.", nameof(destPropertyName));
            }
            SourcePropertyName = sourcePropertyName;
            PropertyNameToAdd = propertyNameToAdd;
            DestPropertyName = destPropertyName;
        }

        protected override Task<DerivationResult> DeriveInternal(object itemToDerive, DerivationContext derivationContext, CancellationToken cancellationToken = default)
        {
            if (!itemToDerive.TryGetProperty(DestPropertyName, out PropertyInfo destPropertyInfo))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TryGetPropertyValue(SourcePropertyName, out object sourceValue))
            {
                return Task.FromResult(Failure);
            }

            if (!sourceValue.TryChangeType(out int sourceIntValue))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TryGetPropertyValue(PropertyNameToAdd, out object toAddValue))
            {
                return Task.FromResult(Failure);
            }

            if (!toAddValue.TryChangeType(out int toAddIntValue))
            {
                return Task.FromResult(Failure);
            }

            if (!itemToDerive.TrySetPropertyValue(destPropertyInfo, sourceIntValue + toAddIntValue))
            {
                return Task.FromResult(Failure);
            }

            return Task.FromResult(Success);
        }
    }
}
