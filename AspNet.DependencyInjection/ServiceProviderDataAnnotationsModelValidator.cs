using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Metadata;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Validators;

namespace AspNet.DependencyInjection
{
    /// <summary>
    /// A System.Web.Http.Validation.ModelValidator based on DataAnnotationsModelValidator; 
    /// extended to provide a service provider in the <see cref="ValidationContext"/>
    /// </summary>
    public class ServiceProviderDataAnnotationsModelValidator : DataAnnotationsModelValidator
    {
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the AspNet.DependencyInjection.ServiceProviderDataAnnotationsModelValidator class.
        /// </summary>
        /// <param name="validatorProviders">The validation providers to pass to the base.</param>
        /// <param name="attribute">The attribute to pass to the base.</param>
        /// <param name="serviceProvider">The service provider to provide to <see cref="ValidationContext"/>.</param>
        public ServiceProviderDataAnnotationsModelValidator(IEnumerable<ModelValidatorProvider> validatorProviders, ValidationAttribute attribute, IServiceProvider serviceProvider = null)
            : base(validatorProviders, attribute)
            => ServiceProvider = serviceProvider;

        /// <summary>
        /// Validates the model and returns the validation errors if any.
        /// </summary>
        /// <param name="metadata">The model metadata.</param>
        /// <param name="container">The container for the model.</param>
        /// <returns>A list of validation error messages for the model, or an empty list if no errors have occurred.</returns>
        public override IEnumerable<ModelValidationResult> Validate(ModelMetadata metadata, object container)
        {
            ValidationContext context = new ValidationContext(container ?? metadata.Model, ServiceProvider, null);
            context.DisplayName = metadata.GetDisplayName();

            ValidationResult result = Attribute.GetValidationResult(metadata.Model, context);
            if (result != ValidationResult.Success)
            {
                yield return new ModelValidationResult
                {
                    Message = result.ErrorMessage
                };
            }
        }
    }
}
