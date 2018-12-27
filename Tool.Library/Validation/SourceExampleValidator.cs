using FluentValidation;
using Framework.Validation;
using Library.DataModel;
using Tool.Framework.Validation;
using Tool.Library.Dto;

namespace Tool.Library.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="SourceExample"/>.
    /// </summary>
    public class SourceExampleValidator : AbstractValidator<SourceExample>
    {
        /// <summary>
        /// The DI injected <see cref="KeyedDataValidationRule{TKey, TValue}"/> for <see cref="YesNoLookupData"/>.
        /// </summary>
        protected readonly KeyedDataValidationRule<string, YesNoLookupData> YesNoKeyedDataValidationRule;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExampleValidator" /> class.
        /// </summary>
        /// <param name="yesNoKeyedDataValidationRule">
        /// The <see cref="KeyedDataValidationRule{TKey, TValue}"/> for <see cref="YesNoLookupData"/>.
        /// </param>
        public SourceExampleValidator(KeyedDataValidationRule<string, YesNoLookupData> yesNoKeyedDataValidationRule)
        {
            // let's save this for later in case something else is overriden that needs it. 
            YesNoKeyedDataValidationRule = yesNoKeyedDataValidationRule;

            // add validation rules
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

            RuleFor(source => source.TestString).NotNullOrWhiteSpace().Must(DataTypeValidation.String)
                // use external validation rule.
                .MustAsync(YesNoKeyedDataValidationRule.ValidateKeyAsync);

            RuleFor(source => source.TestTimeSpan).NotNullOrWhiteSpace().Must(DataTypeValidation.TimeSpan);

            RuleFor(source => source.TestUint16).NotNullOrWhiteSpace().Must(DataTypeValidation.UShort);

            RuleFor(source => source.TestUint32).NotNullOrWhiteSpace().Must(DataTypeValidation.UInt);

            RuleFor(source => source.TestUint64).NotNullOrWhiteSpace().Must(DataTypeValidation.ULong);
        }
    }
}
