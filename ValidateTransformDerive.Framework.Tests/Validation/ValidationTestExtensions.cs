using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    public static class ValidationTestExtensions
    {
        public static void StringIsRequired<T>(this IValidator<T> validator, Expression<Func<T, string>> expression, params IConvertible[] validValues) where T : class, new()
        {
            foreach (var value in validValues)
            {
                validator.ShouldNotHaveValidationErrorFor(expression, Convert.ToString(value));
            }
            validator.ShouldHaveValidationErrorFor(expression, string.Empty);
            validator.ShouldHaveValidationErrorFor(expression, null as string);
        }
    }
}
