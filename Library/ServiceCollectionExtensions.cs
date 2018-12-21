using Framework;
using Library.DataModels;
using Library.DataModels.Transform;
using Library.DataProvider;
using Library.Dto;
using Library.Transform;
using Microsoft.Extensions.DependencyInjection;

namespace Library
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

            // Data services
            services.AddCachedKeyedDataProvider<string, YesNoLookupData, YesNoLookupDataKeyValuePairTransform, YesNoLookupDataProvider>();
            services.AddCachedKeyedDataProvider<string, StateLookupData, StateLookupDataKeyValuePairTransform, StateLookupDataProvider>();

            // Transformation services
            services.AddTransformationService<SourceExample, DestExample, SourceExampleToDestExampleTransformer>();
        }
    }
}
