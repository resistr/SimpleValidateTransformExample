using FluentValidation;
using ValidateTransformDerive.Framework.Dto;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="SourceExample"/>.
    /// </summary>
    public class SourceExampleValidator : AbstractValidator<SourceExample>
    {
        protected readonly IValidator<Address> AddressValidator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExampleValidator" /> class.
        /// </summary>
        public SourceExampleValidator(IValidator<Address> addressValidator)
        {
            AddressValidator = addressValidator;

            // add validation rules
            RuleFor(source => source.Addresses).Required();

            RuleForEach(source => source.Addresses).SetValidator(AddressValidator);

            RuleFor(source => source.TestBool).Required().IsBool();

            RuleFor(source => source.TestByte).Required().IsByte();

            RuleFor(source => source.TestChar).Required().IsChar();

            RuleFor(source => source.TestDateTime).Required().IsDateTime();

            RuleFor(source => source.TestDateTimeOffset).Required().IsDateTimeOffset();

            RuleFor(source => source.TestDecimal).Required().IsDecimal();

            RuleFor(source => source.TestDouble).Required().IsDouble();

            RuleFor(source => source.TestFloat).Required().IsFloat();

            RuleFor(source => source.TestGuid).Required().IsGuid();

            RuleFor(source => source.TestInt16).Required().IsShort();

            RuleFor(source => source.TestInt32).Required().IsInt();

            RuleFor(source => source.TestInt64).Required().IsLong();

            RuleFor(source => source.TestSbyte).Required().IsSByte();

            RuleFor(source => source.TestSingle).Required().IsFloat();

            RuleFor(source => source.TestString).Required();

            RuleFor(source => source.TestTimeSpan).Required().IsTimeSpan();

            RuleFor(source => source.TestUint16).Required().IsUShort();

            RuleFor(source => source.TestUint32).Required().IsUInt();

            RuleFor(source => source.TestUint64).Required().IsULong();
        }
    }
}
