using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Validation
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register a <see cref="IKeyedDataValidationRule{TKey, TValue}"/>. 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddKeyedDataValidator<TKey, TValue>(this IServiceCollection services)
            where TValue : IProvideValue
        {
            // keyed data validator; scoped to access external data.
            services.AddScoped<IKeyedDataValidationRule<TKey, TValue>, KeyedDataValidationRule<TKey, TValue>>();
        }

        /// <summary>
        /// Register a <see cref="IValidator{T}"/>. 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddValidator<TValue, TValidator>(this IServiceCollection services)
            where TValidator : class, IValidator<TValue>
        {
            // validator; scoped to access external data.
            services.AddScoped<IValidator<TValue>, TValidator>();
            services.AddScoped<IValidator, TValidator>();
        }
    }
}
