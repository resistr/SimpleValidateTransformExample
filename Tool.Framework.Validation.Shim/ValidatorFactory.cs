using FluentValidation;
using System;

namespace Tool.Framework.Validation.Shim
{
    public class ValidatorFactory : ValidatorFactoryBase
    {
        protected readonly IServiceProvider ServiceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        public override IValidator CreateInstance(Type validatorType)
            => ServiceProvider.GetService(validatorType) as IValidator;
    }
}
