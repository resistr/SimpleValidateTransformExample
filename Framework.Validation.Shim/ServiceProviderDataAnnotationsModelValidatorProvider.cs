using System;
using System.Web.Http.Validation.Providers;

namespace Framework.Validation.Shim
{
    /// <summary>
    /// Represents an implementation of System.Web.Http.Validation.ModelValidatorProvider
    /// which providers validators for attributes which derive from System.ComponentModel.DataAnnotations.ValidationAttribute.
    /// It also provides a validator for types which implement System.ComponentModel.DataAnnotations.IValidatableObject.
    /// To support client side validation, you can either register adapters through the
    /// static methods on this class, or by having your validation attributes implement
    /// System.Web.Http.Validation.IClientValidatable. The logic to support IClientValidatable
    /// is implemented in System.Web.Http.Validation.Validators.DataAnnotationsModelValidator.
    /// </summary>
    public class ServiceProviderDataAnnotationsModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the AspNet.DependencyInjection.ServiceProviderDataAnnotationsModelValidatorProvider class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to provide to <see cref="System.ComponentModel.DataAnnotations.ValidationContext"/>.</param>
        public ServiceProviderDataAnnotationsModelValidatorProvider(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            // Replace the default adapter factory.
            RegisterDefaultAdapterFactory(
                (validatorProviders, attribute) =>
                    new ServiceProviderDataAnnotationsModelValidator(validatorProviders, attribute, serviceProvider)
            );

            // Replace the default validatable object adaptor. 
            RegisterDefaultValidatableObjectAdapterFactory(
                (validatorProviders) => new ServiceProviderValidatableObjectAdapter(validatorProviders, serviceProvider)
            );
        }
    }
}
