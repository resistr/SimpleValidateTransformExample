using System;
using System.Globalization;
using System.Reflection;

namespace Framework.Derivation
{
    /// <summary>
    /// Serves as the base class for all derivation attributes.
    /// </summary>
    public abstract class DerivationAttribute : Attribute
    {
        private string _errorMessage;
        private string _errorMessageResourceName;
        private Type _errorMessageResourceType;
        private string _defaultErrorMessage;

        private Func<string> ErrorMessageResourceAccessor;
        private volatile bool HasBaseDoDerivation;

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationAttribute class.
        /// </summary>
        protected DerivationAttribute() : this(() => "The field {0} is not derivable.") { }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationAttribute class
        /// by using the error message to associate with a derivation errors.
        /// </summary>
        /// <param name="errorMessage">The error message to associate with a derivation errors.</param>
        protected DerivationAttribute(string errorMessage) : this(() => errorMessage) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationAttribute class
        /// by using the function that enables access to validation resources.
        /// </summary>
        /// <param name="errorMessageAccessor">The function that enables access to validation resources.</param>
        /// <exception cref="ArgumentNullException">If errorMessageAccessor is null.</exception>
        protected DerivationAttribute(Func<string> errorMessageAccessor)
            => ErrorMessageResourceAccessor = errorMessageAccessor;

        internal string DefaultErrorMessage
        {
            get
            {
                return _defaultErrorMessage;
            }
            set
            {
                _defaultErrorMessage = value;
                ErrorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        /// <summary>
        /// Gets or sets an error message to associate with a validation control if derivation fails.
        /// </summary>
        protected string ErrorMessageString
        {
            get
            {
                SetupResourceAccessor();
                return ErrorMessageResourceAccessor();
            }
        }

        internal bool CustomErrorMessageSet { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the attribute requires derivation context.
        /// </summary>
        public virtual bool RequiresDerivationContext { get; } = false;

        /// <summary>
        /// Gets or sets an error message to associate with a validation control if derivation fails.
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return _errorMessage ?? _defaultErrorMessage;
            }
            set
            {
                _errorMessage = value;
                ErrorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;

                if (value == null)
                {
                    _defaultErrorMessage = null;
                }
            }
        }

        /// <summary>
        /// Gets or sets the error message resource name to use in order to look up the ErrorMessageResourceType
        /// property value if derivation fails.
        /// </summary>
        public string ErrorMessageResourceName
        {
            get
            {
                return _errorMessageResourceName;
            }
            set
            {
                _errorMessageResourceName = value;
                ErrorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        /// <summary>
        /// Gets or sets the resource type to use for error-message lookup if derivation
        /// fails.
        /// </summary>
        public Type ErrorMessageResourceType
        {
            get
            {
                return _errorMessageResourceType;
            }
            set
            {
                _errorMessageResourceType = value;
                ErrorMessageResourceAccessor = null;
                CustomErrorMessageSet = true;
            }
        }

        private void SetupResourceAccessor()
        {
            if (ErrorMessageResourceAccessor == null)
            {
                string localErrorMessage = ErrorMessage;
                bool resourceNameSet = !string.IsNullOrEmpty(_errorMessageResourceName);
                bool errorMessageSet = !string.IsNullOrEmpty(_errorMessage);
                bool resourceTypeSet = _errorMessageResourceType != null;
                bool defaultMessageSet = !string.IsNullOrEmpty(_defaultErrorMessage);

                if ((resourceNameSet && errorMessageSet) || !(resourceNameSet || errorMessageSet || defaultMessageSet))
                {
                    throw new InvalidOperationException("Either ErrorMessageString or ErrorMessageResourceName must be set, but not both.");
                }

                if (resourceTypeSet != resourceNameSet)
                {
                    throw new InvalidOperationException("Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute.");
                }

                if (resourceNameSet)
                {
                    SetResourceAccessorByPropertyLookup();
                }
                else
                {
                    ErrorMessageResourceAccessor = delegate {
                        return localErrorMessage;
                    };
                }
            }
        }

        private void SetResourceAccessorByPropertyLookup()
        {
            if (_errorMessageResourceType != null && !string.IsNullOrEmpty(_errorMessageResourceName))
            {
                var property = _errorMessageResourceType.GetProperty(_errorMessageResourceName, BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);
                if (property != null)
                {
                    MethodInfo propertyGetter = property.GetGetMethod(true);
                    if (propertyGetter == null || (!propertyGetter.IsAssembly && !propertyGetter.IsPublic))
                    {
                        property = null;
                    }
                }
                if (property == null)
                {
                    throw new InvalidOperationException(
                        String.Format(
                        CultureInfo.CurrentCulture,
                        "The resource type '{0}' does not have an accessible static property named '{1}'.",
                        _errorMessageResourceType.FullName,
                        _errorMessageResourceName));
                }
                if (property.PropertyType != typeof(string))
                {
                    throw new InvalidOperationException(
                        String.Format(
                        CultureInfo.CurrentCulture,
                        "The property '{0}' on resource type '{1}' is not a string type.",
                        property.Name,
                        _errorMessageResourceType.FullName));
                }

                ErrorMessageResourceAccessor = delegate {
                    return (string)property.GetValue(null, null);
                };
            }
            else
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "Both ErrorMessageResourceType and ErrorMessageResourceName need to be set on this attribute."));
            }
        }

        /// <summary>
        /// Applies formatting to an error message, based on the data field where the error
        /// occurred.
        /// </summary>
        /// <param name="name">The name to include in the formatted message.</param>
        /// <returns>An instance of the formatted error message.</returns>
        public virtual string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }

        /// <summary>
        /// Does derivation for the specified value of the object.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>True if the specified value was derived; otherwise, false.</returns>
        public virtual bool DoDerivation(object value)
        {
            if (!HasBaseDoDerivation)
            {
                HasBaseDoDerivation = true;
            }

            return DoDerivation(value, null) == null;
        }

        /// <summary>
        /// Derives the specified value with respect to the current derivation context.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context information about the derivation operation.</param>
        /// <returns>An instance of the <see cref="DerivationResult"/> class.</returns>
        protected virtual DerivationResult DoDerivation(object value, DerivationContext derivationContext)
        {
            if (HasBaseDoDerivation)
            {
                throw new NotImplementedException("DoDerivation(object value) has not been implemented by this class.  The preferred entry point is GetDerivationResult() and classes should override DoDerivation(object value, DerivationContext context).");
            }

            DerivationResult result = DerivationResult.Success;

            if (!DoDerivation(value))
            {
                string[] memberNames = derivationContext.MemberName != null ? new string[] { derivationContext.MemberName } : null;
                result = new DerivationResult(FormatErrorMessage(derivationContext.DisplayName), memberNames);
            }

            return result;
        }

        /// <summary>
        /// Derives the specified value with respect to the current derivation context.
        /// </summary>
        /// <param name="value">The value to derive.</param>
        /// <param name="derivationContext">The context information about the derivation operation.</param>
        /// <returns>An instance of the <see cref="DerivationResult"/> class.</returns>
        public DerivationResult GetDerivationResult(object value, DerivationContext derivationContext)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            DerivationResult result = DoDerivation(value, derivationContext);

            if (result != null)
            {
                bool hasErrorMessage = (result != null) ? !string.IsNullOrEmpty(result.ErrorMessage) : false;
                if (!hasErrorMessage)
                {
                    string errorMessage = FormatErrorMessage(derivationContext.DisplayName);
                    result = new DerivationResult(errorMessage, result.MemberNames);
                }
            }

            return result;
        }

        /// <summary>
        /// Derives the specified object.
        /// </summary>
        /// <param name="value">The value of the object to derive.</param>
        /// <param name="name">The name to include in the error message.</param>
        /// <exception cref="DerivationException">If derivation fails.</exception>
        public void Derive(object value, string name)
        {
            if (!DoDerivation(value))
            {
                throw new DerivationException(FormatErrorMessage(name), this, value);
            }
        }

        /// <summary>
        /// Derives the specified object.
        /// </summary>
        /// <param name="value">The value of the object to derive.</param>
        /// <param name="derivationContext">
        /// The <see cref="DerivationContext"/> object that describes the context where
        /// the derivations are performed. This parameter cannot be null.
        /// </param>
        /// <exception cref="ArgumentNullException">If derivationContext is not provided.</exception>
        /// <exception cref="DerivationException">If derivation fails.</exception>
        public void Derive(object value, DerivationContext derivationContext)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }

            DerivationResult result = GetDerivationResult(value, derivationContext);

            if (result != null)
            {
                throw new DerivationException(result, this, value);
            }
        }
    }
}
