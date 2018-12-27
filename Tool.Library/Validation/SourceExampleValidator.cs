using FluentValidation;
using Framework.Validation;
using Library.DataModel;
using Tool.Framework.Validation;
using Tool.Library.Dto;

namespace Tool.Library.Validation
{
    public class SourceExampleValidator : AbstractValidator<SourceExample>
    {
        protected readonly KeyedDataValidationRule<string, YesNoLookupData> YesNoKeyedDataValidationRule;

        public SourceExampleValidator(KeyedDataValidationRule<string, YesNoLookupData> yesNoKeyedDataValidationRule)
        {
            YesNoKeyedDataValidationRule = yesNoKeyedDataValidationRule;

            RuleFor(source => source.TestBool).NotNullOrWhiteSpace().Must(DataTypeValidation.Bool);

            RuleFor(source => source.TestByte).NotNullOrWhiteSpace().Must(DataTypeValidation.Byte);

            RuleFor(source => source.TestChar).NotNullOrWhiteSpace().Must(DataTypeValidation.Char);

            RuleFor(source => source.TestDateTime).NotNullOrWhiteSpace().Must(DataTypeValidation.DateTime);

            RuleFor(source => source.TestDateTimeOffset).NotNullOrWhiteSpace().Must(DataTypeValidation.DateTimeOffset);

            RuleFor(source => source.TestDecimal).NotNullOrWhiteSpace().Must(DataTypeValidation.Decimal);

            RuleFor(source => source.TestDouble).NotNullOrWhiteSpace().Must(DataTypeValidation.Double);

            RuleFor(source => source.TestFloat).NotNullOrWhiteSpace().Must(DataTypeValidation.Float);

            RuleFor(source => source.TestGuid).NotNullOrWhiteSpace().Must(DataTypeValidation.Guid);

            RuleFor(source => source.TestInt16).NotNullOrWhiteSpace().Must(DataTypeValidation.Short);

            RuleFor(source => source.TestInt32).NotNullOrWhiteSpace().Must(DataTypeValidation.Int);

            RuleFor(source => source.TestInt64).NotNullOrWhiteSpace().Must(DataTypeValidation.Long);

            RuleFor(source => source.TestSbyte).NotNullOrWhiteSpace().Must(DataTypeValidation.Sbyte);

            RuleFor(source => source.TestSingle).NotNullOrWhiteSpace().Must(DataTypeValidation.Float);

            RuleFor(source => source.TestString).NotNullOrWhiteSpace().Must(DataTypeValidation.String).MustAsync(YesNoKeyedDataValidationRule.ValidateKeyAsync);

            RuleFor(source => source.TestTimeSpan).NotNullOrWhiteSpace().Must(DataTypeValidation.TimeSpan);

            RuleFor(source => source.TestUint16).NotNullOrWhiteSpace().Must(DataTypeValidation.UShort);

            RuleFor(source => source.TestUint32).NotNullOrWhiteSpace().Must(DataTypeValidation.UInt);

            RuleFor(source => source.TestUint64).NotNullOrWhiteSpace().Must(DataTypeValidation.ULong);
        }
    }
}
