using FluentValidation;
using ValidateTransformDerive.Framework.Validation;
using ValidateTransformDerive.ImplementationSpecific.DataModel;

namespace ValidateTransformDerive.ImplementationSpecific.Validation
{
    /// <summary>
    /// Fluent Validation <see cref="IValidator"/> for <see cref="SourceExample"/>.
    /// </summary>
    public class SourceExampleValidator : Framework.Validation.SourceExampleValidator
    {
        /// <summary>
        /// The DI injected <see cref="IKeyedDataValidationRule{TKey, TValue}"/> for <see cref="YesNoLookupData"/>.
        /// </summary>
        protected readonly IKeyedDataValidationRule<string, YesNoLookupData> YesNoKeyedDataValidationRule;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExampleValidator" /> class.
        /// </summary>
        /// <param name="yesNoKeyedDataValidationRule">
        /// The <see cref="IKeyedDataValidationRule{TKey, TValue}"/> for <see cref="YesNoLookupData"/>.
        /// </param>
        public SourceExampleValidator(IKeyedDataValidationRule<string, YesNoLookupData> yesNoKeyedDataValidationRule)
            : base()
        {
            // let's save this for later in case something else is overriden that needs it. 
            YesNoKeyedDataValidationRule = yesNoKeyedDataValidationRule;

            // add validation rules
            RuleFor(source => source.TestString)
                // use external validation rule.
                .MustAsync(YesNoKeyedDataValidationRule.ValidateKeyAsync);
        }
    }
}
