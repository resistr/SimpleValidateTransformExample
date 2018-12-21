using System;
using System.Globalization;
using System.Reflection;

namespace Framework.Derivation
{
    /// <summary>
    /// Specifies a custom derivation method that is used to derive a property or class instance.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Parameter, AllowMultiple = true)]
    public sealed class CustomDerivationAttribute : DerivationAttribute
    {

        private MethodInfo _methodInfo;
        private bool _isSingleArgumentMethod;
        private string _lastMessage;
        private Type _valuesType;
        private Lazy<string> _malformedErrorMessage;
        private Tuple<string, Type> _typeId;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomDerivationAttribute"/> class.
        /// </summary>
        /// <param name="derivorType">The type that contains the method that performs custom derivation.</param>
        /// <param name="method">The method that performs custom derivation.</param>
        public CustomDerivationAttribute(Type derivorType, string method)
            : base(() => "{0} is not derivable.")
        {
            DerivorType = derivorType;
            Method = method;
            _malformedErrorMessage = new Lazy<string>(CheckAttributeWellFormed);
        }

        /// <summary>
        /// Gets the type that performs custom derivation.
        /// </summary>
        public Type DerivorType { get; private set; }

        /// <summary>
        /// Gets the derivation method.
        /// </summary>
        public string Method { get; private set; }

        public override object TypeId
        {
            get
            {
                if (_typeId == null)
                {
                    _typeId = new Tuple<string, Type>(Method, DerivorType);
                }
                return _typeId;
            }
        }

        protected override DerivationResult DoDerivation(object value, DerivationContext derivationContext)
        {
            ThrowIfAttributeNotWellFormed();

            MethodInfo methodInfo = _methodInfo;

            object convertedValue;
            if (!TryConvertValue(value, out convertedValue))
            {
                return new DerivationResult(String.Format(CultureInfo.CurrentCulture, "Could not convert the value of type '{0}' to '{1}' as expected by method {2}.{3}.",
                                                    (value != null ? value.GetType().ToString() : "null"), _valuesType, DerivorType, Method));
            }

            try
            {
                object[] methodParams = _isSingleArgumentMethod
                                            ? new object[] { convertedValue }
                                            : new object[] { convertedValue, derivationContext };

                DerivationResult result = (DerivationResult)methodInfo.Invoke(null, methodParams);

                _lastMessage = null;

                if (result != null)
                {
                    _lastMessage = result.ErrorMessage;
                }

                return result;
            }
            catch (TargetInvocationException tie)
            {
                if (tie.InnerException != null)
                {
                    throw tie.InnerException;
                }

                throw;
            }
        }

        public override string FormatErrorMessage(string name)
        {
            ThrowIfAttributeNotWellFormed();

            if (!string.IsNullOrEmpty(_lastMessage))
            {
                return String.Format(CultureInfo.CurrentCulture, _lastMessage, name);
            }

            return base.FormatErrorMessage(name);
        }

        private string CheckAttributeWellFormed()
        {
            return DerivationDerivorTypeParameter() ?? DerivationMethodParameter();
        }

        private string DerivationDerivorTypeParameter()
        {
            if (DerivorType == null)
            {
                return "The CustomDerivationAttribute.DeriverType was not specified.";
            }

            if (!DerivorType.IsVisible)
            {
                return String.Format(CultureInfo.CurrentCulture, "The custom derivation type '{0}' must be public.", DerivorType.Name);
            }

            return null;
        }

        private string DerivationMethodParameter()
        {
            if (String.IsNullOrEmpty(Method))
            {
                return "The CustomDerivationAttribute.Method was not specified.";
            }

            MethodInfo methodInfo = DerivorType.GetMethod(Method, BindingFlags.Public | BindingFlags.Static);
            if (methodInfo == null)
            {
                return String.Format(CultureInfo.CurrentCulture, "The CustomDerivationAttribute method '{0}' does not exist in type '{1}' or is not public and static.", Method, DerivorType.Name);
            }

            if (methodInfo.ReturnType != typeof(DerivationResult))
            {
                return String.Format(CultureInfo.CurrentCulture, "The CustomDerivationAttribute method '{0}' in type '{1}' must return DerivationResult.  Use DerivationResult.Success to represent success.", Method, DerivorType.Name);
            }

            ParameterInfo[] parameterInfos = methodInfo.GetParameters();

            if (parameterInfos.Length == 0 || parameterInfos[0].ParameterType.IsByRef)
            {
                return String.Format(CultureInfo.CurrentCulture, "The CustomDerivationAttribute method '{0}' in type '{1}' must match the expected signature: public static DerivationResult {0}(object value, DerivationContext context).  The value can be strongly typed.  The DerivationContext parameter is optional.", Method, DerivorType.Name);
            }

            _isSingleArgumentMethod = (parameterInfos.Length == 1);

            if (!_isSingleArgumentMethod)
            {
                if ((parameterInfos.Length != 2) || (parameterInfos[1].ParameterType != typeof(DerivationContext)))
                {
                    return String.Format(CultureInfo.CurrentCulture, "The CustomDerivationAttribute method '{0}' in type '{1}' must match the expected signature: public static DerivationResult {0}(object value, DerivationContext context).  The value can be strongly typed.  The DerivationContext parameter is optional.", Method, DerivorType.Name);
                }
            }

            _methodInfo = methodInfo;
            _valuesType = parameterInfos[0].ParameterType;
            return null;
        }

        private void ThrowIfAttributeNotWellFormed()
        {
            string errorMessage = _malformedErrorMessage.Value;
            if (errorMessage != null)
            {
                throw new InvalidOperationException(errorMessage);
            }
        }

        private bool TryConvertValue(object value, out object convertedValue)
        {
            convertedValue = null;
            Type t = _valuesType;

            if (value == null)
            {
                if (t.IsValueType && (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(Nullable<>)))
                {
                    return false;
                }

                return true;
            }

            if (t.IsAssignableFrom(value.GetType()))
            {
                convertedValue = value;
                return true;
            }

            try
            {
                convertedValue = Convert.ChangeType(value, t, CultureInfo.CurrentCulture);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (NotSupportedException)
            {
                return false;
            }
        }
    }
}
