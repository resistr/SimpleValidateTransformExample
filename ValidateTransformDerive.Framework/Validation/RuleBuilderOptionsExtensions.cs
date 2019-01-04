using FluentValidation;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Common extensions for <see cref="IRuleBuilderOptions{T, TProperty}"/>.
    /// </summary>
    public static class RuleBuilderOptionsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="rule"></param>
        /// <param name="validationMethodName"></param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, TProperty> CreateMessageCode<T, TProperty>(
            this IRuleBuilderOptions<T, TProperty> rule, 
            string validationMethodName
            )
            => rule.WithErrorCode(validationMethodName).WithMessage(validationMethodName);
    }
}
