using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http.Validation;

namespace Framework.DependencyInjection.Shim
{

    public static class ModelValidationResultExtensions
    {
        /// <summary>
        /// Converts a collection of <see cref="ValidationResult"/> to <see cref="ModelValidationResult"/>.
        /// </summary>
        /// <param name="results">The collection of <see cref="ValidationResult"/> to convert.</param>
        /// <returns>The resulting collection of <see cref="ModelValidationResult"/>.</returns>
        public static IEnumerable<ModelValidationResult> ConvertToModelValidationResults(this IEnumerable<ValidationResult> results)
        {
            foreach (ValidationResult result in results)
            {
                if (result != ValidationResult.Success)
                {
                    if (result.MemberNames?.Any() != true)
                    {
                        yield return new ModelValidationResult { Message = result.ErrorMessage };
                    }
                    else
                    {
                        foreach (string memberName in result.MemberNames)
                        {
                            yield return new ModelValidationResult { Message = result.ErrorMessage, MemberName = memberName };
                        }
                    }
                }
            }
        }
    }
}
