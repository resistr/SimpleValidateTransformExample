using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Framework.Derivation
{
    public static class Derivor
    {
        private static DerivationAttributeStore Store = DerivationAttributeStore.Instance;

        public static bool TryDeriveProperty(object value, DerivationContext derivationContext, ICollection<DerivationResult> derivationResults)
        {
            Type propertyType = Store.GetPropertyType(derivationContext);
            string propertyName = derivationContext.MemberName;
            EnsureValidPropertyType(propertyName, propertyType, value);

            bool result = true;
            bool breakOnFirstError = (derivationResults == null);

            IEnumerable<DerivationAttribute> attributes = Store.GetPropertyDerivationAttributes(derivationContext);

            foreach (DerivationError err in GetDerivationErrors(value, derivationContext, attributes, breakOnFirstError))
            {
                result = false;

                if (derivationResults != null)
                {
                    derivationResults.Add(err.DerivationResult);
                }
            }

            return result;
        }

        public static bool TryDeriveObject(object instance, DerivationContext derivationContext, ICollection<DerivationResult> derivationResults)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (derivationContext != null && instance != derivationContext.ObjectInstance)
            {
                throw new ArgumentException("The instance provided must match the ObjectInstance on the DerivationContext supplied.", nameof(instance));
            }

            bool result = true;
            bool breakOnFirstError = (derivationResults == null);

            foreach (DerivationError err in GetObjectDerivationErrors(instance, derivationContext, breakOnFirstError))
            {
                result = false;

                if (derivationResults != null)
                {
                    derivationResults.Add(err.DerivationResult);
                }
            }

            return result;
        }

        public static bool TryDeriveValue(object value, DerivationContext derivationContext, ICollection<DerivationResult> derivationResults, IEnumerable<DerivationAttribute> derivationAttributes)
        {
            bool result = true;
            bool breakOnFirstError = derivationResults == null;

            foreach (DerivationError err in GetDerivationErrors(value, derivationContext, derivationAttributes, breakOnFirstError))
            {
                result = false;

                if (derivationResults != null)
                {
                    derivationResults.Add(err.DerivationResult);
                }
            }

            return result;
        }

        public static void DeriveProperty(object value, DerivationContext derivationContext)
        {
            Type propertyType = Store.GetPropertyType(derivationContext);
            EnsureValidPropertyType(derivationContext.MemberName, propertyType, value);

            IEnumerable<DerivationAttribute> attributes = Store.GetPropertyDerivationAttributes(derivationContext);

            DerivationError err = GetDerivationErrors(value, derivationContext, attributes, false).FirstOrDefault();
            if (err != null)
            {
                err.ThrowDerivationException();
            }
        }

        public static void DeriveObject(object instance, DerivationContext derivationContext)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }
            if (instance != derivationContext.ObjectInstance)
            {
                throw new ArgumentException("The instance provided must match the ObjectInstance on the DerivationContext supplied.", nameof(instance));
            }

            DerivationError err = GetObjectDerivationErrors(instance, derivationContext, false).FirstOrDefault();
            if (err != null)
            {
                err.ThrowDerivationException();
            }
        }

        public static void DeriveValue(object value, DerivationContext derivationContext, IEnumerable<DerivationAttribute> derivationAttributes)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(DerivationContext));
            }

            DerivationError err = GetDerivationErrors(value, derivationContext, derivationAttributes, false).FirstOrDefault();
            if (err != null)
            {
                err.ThrowDerivationException();
            }
        }

        internal static DerivationContext CreateDerivationContext(object instance, DerivationContext derivationContext)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            DerivationContext context = new DerivationContext(instance, derivationContext, derivationContext.Items);
            return context;
        }

        private static bool CanBeAssigned(Type destinationType, object value)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException(nameof(destinationType));
            }

            if (value == null)
            {
                return !destinationType.IsValueType ||
                        (destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == typeof(Nullable<>));
            }

            return destinationType.IsAssignableFrom(value.GetType());
        }

        private static void EnsureValidPropertyType(string propertyName, Type propertyType, object value)
        {
            if (!CanBeAssigned(propertyType, value))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The value for property '{0}' must be of type '{1}'.", propertyName, propertyType), nameof(value));
            }
        }

        private static IEnumerable<DerivationError> GetObjectDerivationErrors(object instance, DerivationContext derivationContext, bool breakOnFirstError)
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }

            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            List<DerivationError> errors = new List<DerivationError>();
            errors.AddRange(GetObjectPropertyDerivationErrors(instance, derivationContext, breakOnFirstError));

            if (errors.Any())
            {
                return errors;
            }

            IEnumerable<DerivationAttribute> attributes = Store.GetTypeDerivationAttributes(derivationContext);
            errors.AddRange(GetDerivationErrors(instance, derivationContext, attributes, breakOnFirstError));

            if (errors.Any())
            {
                return errors;
            }

            IDerivableObject derivable = instance as IDerivableObject;
            if (derivable != null)
            {
                IEnumerable<DerivationResult> results = derivable.Derive(derivationContext);

                foreach (DerivationResult result in results.Where(r => r != DerivationResult.Success))
                {
                    errors.Add(new DerivationError(null, instance, result));
                }
            }

            return errors;
        }

        private static IEnumerable<DerivationError> GetObjectPropertyDerivationErrors(object instance, DerivationContext derivationContext, bool breakOnFirstError)
        {
            ICollection<KeyValuePair<DerivationContext, object>> properties = GetPropertyValues(instance, derivationContext);
            List<DerivationError> errors = new List<DerivationError>();

            foreach (KeyValuePair<DerivationContext, object> property in properties)
            {
                IEnumerable<DerivationAttribute> attributes = Store.GetPropertyDerivationAttributes(property.Key);

                errors.AddRange(GetDerivationErrors(property.Value, property.Key, attributes, breakOnFirstError));

                if (breakOnFirstError && errors.Any())
                {
                    break;
                }
            }

            return errors;
        }

        private static ICollection<KeyValuePair<DerivationContext, object>> GetPropertyValues(object instance, DerivationContext derivationContext)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(instance);
            List<KeyValuePair<DerivationContext, object>> items = new List<KeyValuePair<DerivationContext, object>>(properties.Count);
            foreach (PropertyDescriptor property in properties)
            {
                DerivationContext context = CreateDerivationContext(instance, derivationContext);
                context.MemberName = property.Name;

                if (Store.GetPropertyDerivationAttributes(context).Any())
                {
                    items.Add(new KeyValuePair<DerivationContext, object>(context, property.GetValue(instance)));
                }
            }
            return items;
        }

        private static IEnumerable<DerivationError> GetDerivationErrors(object value, DerivationContext derivationContext, IEnumerable<DerivationAttribute> attributes, bool breakOnFirstError)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            List<DerivationError> errors = new List<DerivationError>();
            DerivationError DerivationError;

            foreach (DerivationAttribute attr in attributes)
            {
                if (!TryDerive(value, derivationContext, attr, out DerivationError))
                {
                    errors.Add(DerivationError);

                    if (breakOnFirstError)
                    {
                        break;
                    }
                }
            }

            return errors;
        }

        private static bool TryDerive(object value, DerivationContext derivationContext, DerivationAttribute attribute, out DerivationError derivationError)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            DerivationResult DerivationResult = attribute.GetDerivationResult(value, derivationContext);
            if (DerivationResult != DerivationResult.Success)
            {
                derivationError = new DerivationError(attribute, value, DerivationResult);
                return false;
            }

            derivationError = null;
            return true;
        }

        private class DerivationError
        {
            internal DerivationError(DerivationAttribute derivationAttribute, object value, DerivationResult derivationResult)
            {
                DerivationAttribute = derivationAttribute;
                DerivationResult = derivationResult;
                Value = value;
            }

            internal object Value { get; set; }

            internal DerivationAttribute DerivationAttribute { get; set; }

            internal DerivationResult DerivationResult { get; set; }

            internal void ThrowDerivationException()
            {
                throw new DerivationException(DerivationResult, DerivationAttribute, Value);
            }
        }
    }
}
