using FluentValidation;

namespace Tool.Framework.Validation
{
    public static class NotNullOrWhiteSpaceValidationRule
    {
        public static IRuleBuilderOptions<T, string> NotNullOrWhiteSpace<T>(this IRuleBuilder<T, string> ruleBuilder)
            => ruleBuilder.Must(prop => !string.IsNullOrWhiteSpace(prop));
    }
}
