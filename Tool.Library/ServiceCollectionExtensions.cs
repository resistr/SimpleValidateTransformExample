using Framework.DataProvider;
using Library.DataModel;
using Library.DataProvider;
using Microsoft.Extensions.DependencyInjection;
using Tool.Framework;
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
        ///  - SourceExampleToDestExampleTransformer
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddClientSpecificTransformations(this IServiceCollection services)
        {
            services.AddFrameworkServices();

            services.AddCachedKeyedDataProvider<string, YesNoLookupData, YesNoLookupDataProvider>();
            services.AddCachedKeyedDataProvider<string, StateLookupData, StateLookupDataProvider>();

            services.AddScoped<KeyedDataValidationRule<string, YesNoLookupData>, KeyedDataValidationRule<string, YesNoLookupData>>();

            services.AddScoped<KeyedDataValueConverter<string, YesNoLookupData, string>, KeyedDataValueConverter<string, YesNoLookupData, string>>();
        }
    }
}
