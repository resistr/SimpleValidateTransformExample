using FluentValidation;
using System;

namespace Tool.Framework.Validation.Shim
{
    /// <summary>
    /// Factory for creating Fluent Validation validators using <see cref="IServiceProvider"/>.
    /// </summary>
    public class ValidatorFactory : ValidatorFactoryBase
    {
        /// <summary>
        /// The <see cref="IServiceProvider"/> to use to create instances of validators.
        /// </summary>
        protected readonly IServiceProvider ServiceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatorFactory" /> class.
        /// </summary>
        /// <param name="serviceProvider">
        /// The <see cref="IServiceProvider"/> to use to create instances of validators.
        /// </param>
        public ValidatorFactory(IServiceProvider serviceProvider)
            => ServiceProvider = serviceProvider;

        /// <summary>
        /// Instantiates the <see cref="IValidator"/>.
        /// </summary>
        /// <param name="validatorType">
        /// The type of validator to create.
        /// </param>
        /// <returns>
        /// The created <see cref="IValidator"/>.
        /// </returns>
        public override IValidator CreateInstance(Type validatorType)
            => ServiceProvider.GetService(validatorType) as IValidator;
    }
}
