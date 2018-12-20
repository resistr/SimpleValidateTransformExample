using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Framework.Derivation
{
    /// <summary>
    /// Defines a helper class that can be used to derive objects, properties, and
    /// methods when it is included in their associated Framework.Derivation.DerivationAttribute
    /// attributes.
    /// </summary>
    public static class Derivor
    {
        private static DerivationAttributeStore Store = DerivationAttributeStore.Instance;

        /// <summary>
        /// Attempts derivation on the specified object using the derivation context
        /// and derivation results collection.
        /// </summary>
        /// <param name="value">The object to derive.</param>
        /// <param name="derivationContext">The context that describes the object to derive.</param>
        /// <param name="derivationResults">A collection to hold each failed derivation.</param>
        /// <returns>True if the object derives; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The value is null.</exception>
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

        /// <summary>
        /// Derives the specified object using the derivation context,
        ///  and derivation results collection.
        /// </summary>
        /// <param name="instance">The object to validate.</param>
        /// <param name="derivationContext">The context that describes the object to derive.</param>
        /// <param name="derivationResults">A collection to hold each failed derivation.</param>
        /// <returns>True if the object derives; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">The instance is null.</exception>
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

        /// <summary>
        /// Returns a value that indicates whether the specified value was derived with the
        /// specified attributes.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="derivationContext">The context that describes the object to derive.</param>
        /// <param name="derivationResults">A collection to hold each failed derivation.</param>
        /// <param name="derivationAttributes">The derivation attributes.</param>
        /// <returns>True if the object derives; otherwise, false.</returns>
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

        /// <summary>
        /// Derives the property.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context that describes the property to derive.</param>
        /// <exception cref="ArgumentNullException">The value cannot be assigned to the property.</exception>
        /// <exception cref="DerivationException">The value parameter is not valid.</exception>
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

        /// <summary>
        /// Derives the specified object using the validation context.
        /// </summary>
        /// <param name="instance">The object to derive.</param>
        /// <param name="derivationContext">The context that describes the object to derive.</param>
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

        /// <summary>
        /// Derives the specified value with the specified attributes.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context that describes the object to derive.</param>
        /// <param name="derivationAttributes">The derivation attributes.</param>
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

        /// <summary>
        /// Creates a derivation context for an object from an existing derivation context.
        /// </summary>
        /// <param name="instance">The object to create the derivation contect for.</param>
        /// <param name="derivationContext">The existing derivation context.</param>
        /// <returns>A new derivation context.</returns>
        /// <exception cref="ArgumentNullException">If derivationContext is not provided.</exception>
        internal static DerivationContext CreateDerivationContext(object instance, DerivationContext derivationContext)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            DerivationContext context = new DerivationContext(instance, derivationContext, derivationContext.Items);
            return context;
        }

        /// <summary>
        /// Determines if the value can be assigned to the destination type.
        /// </summary>
        /// <param name="destinationType">The destination tpye for the value.</param>
        /// <param name="value">The value to check.</param>
        /// <returns>True if the value can be set to the destination type.</returns>
        /// <exception cref="ArgumentNullException">if destination type is not provided.</exception>
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

        /// <summary>
        /// Ensures that a property type is valid for the object provided.
        /// </summary>
        /// <param name="propertyName">The name of the property to check.</param>
        /// <param name="propertyType">The type of the expected for the property.</param>
        /// <param name="value">The value to check.</param>
        /// <exception cref="ArgumentException">If the value can not be assigned to the expected type.</exception>
        private static void EnsureValidPropertyType(string propertyName, Type propertyType, object value)
        {
            if (!CanBeAssigned(propertyType, value))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The value for property '{0}' must be of type '{1}'.", propertyName, propertyType), nameof(value));
            }
        }

        /// <summary>
        /// Does derivation and gets any derivation errors.
        /// </summary>
        /// <param name="instance">The item to derive.</param>
        /// <param name="derivationContext">The context for the item to derive.</param>
        /// <param name="breakOnFirstError">A value indicating if derivation should abort after the first error.</param>
        /// <returns>A collection of derivation errors.</returns>
        /// <exception cref="ArgumentNullException">If instance or derivation context is not provided.</exception>
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

        /// <summary>
        /// Runs derivation and gets any derivation errors for each property on an object.
        /// </summary>
        /// <param name="instance">The object to derive.</param>
        /// <param name="derivationContext">The context of the object to derive.</param>
        /// <param name="breakOnFirstError">A value indicating if derivation should abort after the first error.</param>
        /// <returns>A collection of derivation errors.</returns>
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

        /// <summary>
        /// Get the values for each property in an object.
        /// </summary>
        /// <param name="instance">The instance of the object to derive.</param>
        /// <param name="derivationContext">The context of the object to derive.</param>
        /// <returns>A collection of key value pairs of derivation context and object of property value for each property.</returns>
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

        /// <summary>
        /// Runs derivation on an object for a list of derivations and gets any derivation errors.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context of the value to derive.</param>
        /// <param name="attributes">The list of attributes to run derivation against.</param>
        /// <param name="breakOnFirstError"></param>
        /// <param name="breakOnFirstError">A value indicating if derivation should abort after the first error.</param>
        /// <returns>A collection of derivation errors.</returns>
        /// <exception cref="ArgumentNullException">If derivation context is not provided.</exception>
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

        /// <summary>
        /// Run derivation and indicate success.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context of the value to derive.</param>
        /// <param name="attribute">The atribute to run derivation for.</param>
        /// <param name="derivationError">The resulting derivation error.</param>
        /// <returns>True if the object derives; otherwise, false.</returns>
        /// <exception cref="ArgumentNullException">If derivation context is not provided.</exception>
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

        /// <summary>
        /// A class representing derivation errors.
        /// </summary>
        private class DerivationError
        {
            /// <summary>
            /// Initializes a new instance of the Framework.Derivation.Derivor.DerivationError class.
            /// </summary>
            /// <param name="derivationAttribute">The derivation attribute that created the error.</param>
            /// <param name="value">The value being derived that created the error.</param>
            /// <param name="derivationResult">The derivation result.</param>
            internal DerivationError(DerivationAttribute derivationAttribute, object value, DerivationResult derivationResult)
            {
                DerivationAttribute = derivationAttribute;
                DerivationResult = derivationResult;
                Value = value;
            }

            /// <summary>
            /// The value being derived.
            /// </summary>
            internal object Value { get; set; }

            /// <summary>
            /// The derivation attribure ran.
            /// </summary>
            internal DerivationAttribute DerivationAttribute { get; set; }

            /// <summary>
            /// The result of the derivation.
            /// </summary>
            internal DerivationResult DerivationResult { get; set; }

            /// <summary>
            /// Throws a <see cref="DerivationException"/> for this error.
            /// </summary>
            /// <exception cref="DerivationException">Always.</exception>
            internal void ThrowDerivationException()
            {
                throw new DerivationException(DerivationResult, DerivationAttribute, Value);
            }
        }
    }
}
