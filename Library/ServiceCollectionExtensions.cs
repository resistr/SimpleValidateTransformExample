using Framework;
using Framework.DataProvider;
using Framework.Transformation;
using Library.DataModel;
using Library.DataModel.Transform;
using Library.DataProvider;
using Library.Dto;
using Library.Transform;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

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

            //Transforms
            services.AddSingleton<ITransform, StateLookupDataKeyValuePairTransform>();
            services.AddSingleton<ITransform, YesNoLookupDataKeyValuePairTransform>();
            services.AddSingleton<ITransform<StateLookupData, KeyValuePair<string, StateLookupData>>, StateLookupDataKeyValuePairTransform>();
            services.AddSingleton<ITransform<YesNoLookupData, KeyValuePair<string, YesNoLookupData>>, YesNoLookupDataKeyValuePairTransform>();

            // Data services
            services.AddCachedKeyedDataProvider<string, YesNoLookupData, YesNoLookupDataProvider>();
            services.AddCachedKeyedDataProvider<string, StateLookupData, StateLookupDataProvider>();

            // Transformation services
            services.AddTransformationService<SourceExample, DestExample, SourceExampleToDestExampleTransformer>();
        }
    }
}
