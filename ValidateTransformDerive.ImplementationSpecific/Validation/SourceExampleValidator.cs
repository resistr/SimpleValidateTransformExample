using ValidateTransformDerive.Framework.DataProvider;
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
        /// The DI injected <see cref="IProvideKeyedData{YesNoLookupData}"/> to use for validation.
        /// </summary>
        protected readonly IProvideKeyedData<YesNoLookupData, string, string> YesNoKeyedData;

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExampleValidator" /> class.
        /// </summary>
        /// <param name="yesNoKeyedDataValidationRule">
        /// The <see cref="IKeyedDataValidationRule{TKey, TValue}"/> for <see cref="YesNoLookupData"/>.
        /// </param>
        public SourceExampleValidator(IProvideKeyedData<YesNoLookupData, string, string> yesNoKeyedData)
            : base()
        {
            // let's save this for later in case something else is overriden that needs it. 
            YesNoKeyedData = yesNoKeyedData;

            // add validation rules
            RuleFor(source => source.TestString).Required().ValidateKey(YesNoKeyedData);
        }
    }
}
