using FluentValidation;
using ValidateTransformDerive.Framework.Dto;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="Address"/>.
    /// </summary>
    public class AddressValidator : AbstractValidator<Address>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressValidator" /> class.
        /// </summary>
        public AddressValidator()
        {
            // add validation rules
            RuleFor(source => source.City).Required();

            RuleFor(source => source.FirstLine).Required();

            RuleFor(source => source.PostalCode).Required();

            RuleFor(source => source.State).Required();
        }
    }
}
