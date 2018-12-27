using FluentValidation;
using Library.DataModel;
using Tool.Framework.Validation;
using Tool.Library.Dto;

namespace Tool.Library.Validation
{
    public class DestExampleValidator : AbstractValidator<DestExample>
    {
        protected readonly KeyedDataValidationRule<string, YesNoLookupData> YesNoKeyedDataValidationRule;

        public DestExampleValidator(KeyedDataValidationRule<string, YesNoLookupData> yesNoKeyedDataValidationRule)
        {
            YesNoKeyedDataValidationRule = yesNoKeyedDataValidationRule;

            RuleFor(source => source.TestBool).NotDefault();

            RuleFor(source => source.TestByte).NotDefault();

            RuleFor(source => source.TestChar).NotDefault();

            RuleFor(source => source.TestDateTime).NotDefault();

            RuleFor(source => source.TestDateTimeOffset).NotDefault();

            RuleFor(source => source.TestDecimal).NotDefault();

            RuleFor(source => source.TestDouble).NotDefault();

            RuleFor(source => source.TestFloat).NotDefault();

            RuleFor(source => source.TestGuid).NotDefault();

            RuleFor(source => source.TestInt16).NotDefault();

            RuleFor(source => source.TestInt32).NotDefault();

            RuleFor(source => source.TestInt64).NotDefault();

            RuleFor(source => source.TestSbyte).NotDefault();

            RuleFor(source => source.TestSingle).NotDefault();

            RuleFor(source => source.TestTimeSpan).NotDefault();

            RuleFor(source => source.TestUint16).NotDefault();

            RuleFor(source => source.TestUint32).NotDefault();

            RuleFor(source => source.TestUint64).NotDefault();

            RuleFor(source => source.TestDeriveStringToBool).NotNullOrWhiteSpace().MustAsync(YesNoKeyedDataValidationRule.ValidateValueAsync);

            RuleFor(source => source.TestDeriveAddedValue).NotDefault();
        }
    }
}
