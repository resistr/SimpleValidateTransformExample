using FluentValidation;

namespace Tool.Framework.Validation
{
    public static class NotDefaultValidationRule
    {
        public static IRuleBuilderOptions<T, TProperty> NotDefault<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
            => ruleBuilder.Must(prop => prop != default);
    }
}
