using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Framework.Validation
{
    public class ValidationService : IValidationService
    {
        protected readonly IServiceProvider ServiceProvider;

        public ValidationService(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public T Validate<T>(T source)
        {
            try
            {
                var validationResults = new List<ValidationResult>();
                if (!Validator.TryValidateObject(source, new ValidationContext(source, ServiceProvider, null), validationResults))
                {
                    throw new ValidationException("Error validating.", validationResults, source);
                }
                return source;
            }
            catch (Exception ex)
            {
                throw new ValidationException("Error validating.", ex);
            }
        }
    }
}
