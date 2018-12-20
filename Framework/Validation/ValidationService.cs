using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Validation
{
    /// <summary>
    /// The service providing the ability to validate objects using <see cref="Validator"/>
    /// </summary>
    public class ValidationService : IValidationService
    {
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the Framework.Validation.ValidationService class.
        /// </summary>
        /// <param name="serviceProvider">The service provider to provide to the <see cref="ValidationContext"/>.</param>
        public ValidationService(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        /// <summary>
        /// Validate the item.
        /// </summary>
        /// <typeparam name="T">The type of the item to validate.</typeparam>
        /// <param name="source">The item to validate.</param>
        /// <returns>The unmodified item post validation.</returns>
        /// <exception cref="ValidationException">If any validation errors occur.</exception>
        public T Validate<T>(T source)
        {
            try
            {
                // place holder for validation results
                var validationResults = new List<ValidationResult>();

                // try validation  
                if (!Validator.TryValidateObject(source, new ValidationContext(source, ServiceProvider, null), validationResults))
                {
                    // validation failure; build and throw a validation exception containing the list of validation results and the source item. 
                    throw new ValidationException("Error validating.", validationResults, source);
                }

                // validation success; return the unmodified object
                return source;
            }
            catch (ValidationException) { throw; } // no need to wrap a validation exception
            catch (Exception ex)
            {
                // some unknown error occured in the validation process; wrap it in a ValidationException
                // likely a validator had an uncaught exception
                throw new ValidationException("Error validating.", ex);
            }
        }
    }
}
