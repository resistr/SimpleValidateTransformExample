using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.Metadata;
using System.Web.Http.Validation;
using System.Web.Http.Validation.Validators;

namespace Framework.DependencyInjection.Shim
{
    /// <summary>
    /// Provides an object adapter that can be validated.
    /// </summary>
    public class ServiceProviderValidatableObjectAdapter : ValidatableObjectAdapter
    {
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the AspNet.DependencyInjection.ServiceProviderValidatableObjectAdapter class.
        /// </summary>
        /// <param name="validatorProviders">The validatop providers to pass to the base.</param>
        /// <param name="serviceProvider">The service provider to provide to <see cref="ValidationContext"/>.</param>
        public ServiceProviderValidatableObjectAdapter(IEnumerable<ModelValidatorProvider> validatorProviders, IServiceProvider serviceProvider = null)
            : base(validatorProviders)
            => ServiceProvider = serviceProvider;

        /// <summary>
        /// Validates the specified object.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="container">The container.</param>
        /// <returns>A list of validation results.</returns>
        public override IEnumerable<ModelValidationResult> Validate(ModelMetadata metadata, object container)
        => (metadata.Model is IValidatableObject validatable)
                ? validatable.Validate(new ValidationContext(validatable, ServiceProvider, null)).ConvertToModelValidationResults()
                : Enumerable.Empty<ModelValidationResult>();
    }
}
