using FluentValidation;
using Library.DataModel;
using Tool.Framework.Validation;
using Tool.Library.Dto;

namespace Tool.Library.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="DestExample"/>.
    /// </summary>
    public class DestExampleValidator : AbstractValidator<DestExample>
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
        public DestExampleValidator(KeyedDataValidationRule<string, YesNoLookupData> yesNoKeyedDataValidationRule)
        {
            // let's save this for later in case something else is overriden that needs it. 
            YesNoKeyedDataValidationRule = yesNoKeyedDataValidationRule;

            // add validation rules
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

            RuleFor(source => source.TestDeriveStringToBool).NotNullOrWhiteSpace()
                // use external validation rule.
                .MustAsync(YesNoKeyedDataValidationRule.ValidateValueAsync);

            RuleFor(source => source.TestDeriveAddedValue).NotDefault();
        }
    }
}
