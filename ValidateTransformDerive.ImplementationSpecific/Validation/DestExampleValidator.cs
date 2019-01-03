using FluentValidation;
using ValidateTransformDerive.Framework.DataProvider;
using ValidateTransformDerive.Framework.Validation;
using ValidateTransformDerive.ImplementationSpecific.DataModel;
using ValidateTransformDerive.ImplementationSpecific.Dto;

namespace ValidateTransformDerive.ImplementationSpecific.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="DestExample"/>.
    /// </summary>
    public class DestExampleValidator : AbstractValidator<DestExample>
    {
        /// <summary>
        /// The DI injected <see cref="IProvideKeyedData{YesNoLookupData}"/> to use for validation.
        /// </summary>
        protected readonly IProvideKeyedData<YesNoLookupData, string, string> YesNoKeyedData;

        public DestExampleValidator(IProvideKeyedData<YesNoLookupData, string, string> yesNoKeyedData)
        {
            // let's save this for later in case something else is overriden that needs it. 
            YesNoKeyedData = yesNoKeyedData;

            // add validation rules
            RuleFor(source => source.TestBool).Required();

            RuleFor(source => source.TestByte).Required();

            RuleFor(source => source.TestChar).Required();

            RuleFor(source => source.TestDateTime).Required();

            RuleFor(source => source.TestDateTimeOffset).Required();

            RuleFor(source => source.TestDecimal).Required();

            RuleFor(source => source.TestDouble).Required();

            RuleFor(source => source.TestFloat).Required();

            RuleFor(source => source.TestGuid).Required();

            RuleFor(source => source.TestInt16).Required();

            RuleFor(source => source.TestInt32).Required();

            RuleFor(source => source.TestInt64).Required();

            RuleFor(source => source.TestSbyte).Required();

            RuleFor(source => source.TestSingle).Required();

            RuleFor(source => source.TestTimeSpan).Required();

            RuleFor(source => source.TestUint16).Required();

            RuleFor(source => source.TestUint32).Required();

            RuleFor(source => source.TestUint64).Required();

            RuleFor(source => source.TestDeriveStringToBool).Required()
                .ValidateValue(YesNoKeyedData);

            RuleFor(source => source.TestDeriveAddedValue).Required();
        }
    }
}
