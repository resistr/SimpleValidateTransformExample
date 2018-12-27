using Framework.DataProvider;
using Library.DataModel;
using Library.DataProvider;
using Microsoft.Extensions.DependencyInjection;
using Tool.Framework;
using Tool.Framework.Derivation;
using Tool.Framework.Transformation;
using Tool.Framework.Validation;

namespace Tool.Library
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register client services. 
        /// 
        ///  - YesNoLookupDataProvider
        ///  - StateLookupDataProvider
        ///  - KeyedDataValidationRules
        ///  - KeyedDataValueConverters
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddClientSpecificTransformations(this IServiceCollection services)
        {
            // add the framework services
            services.AddFrameworkServices();

            // add any data providers
            services.AddCachedKeyedDataProvider<string, YesNoLookupData, YesNoLookupDataProvider>();
            services.AddCachedKeyedDataProvider<string, StateLookupData, StateLookupDataProvider>();

            // add DI injected validation rules. (FluentValidation)
            services.AddScoped<KeyedDataValidationRule<string, YesNoLookupData>, KeyedDataValidationRule<string, YesNoLookupData>>();

            // add DI injected converts and resolvers. (AutoMapper)
            services.AddScoped<KeyedDataValueConverter<string, YesNoLookupData, string>, KeyedDataValueConverter<string, YesNoLookupData, string>>();
        }
    }
}
