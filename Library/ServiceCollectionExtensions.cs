using Framework;
using Framework.DataProvider;
using Framework.Transformation;
using Library.DataModels;
using Library.DataModels.Transform;
using Library.DataProvider;
using Library.Dto;
using Library.Transform;
using Microsoft.Extensions.DependencyInjection;

namespace Library
{
    public static class ServiceCollectionExtensions
    {
        public static void AddClientSpecificTransformations(this IServiceCollection services)
        {
            services.AddFrameworkServices();

            // Data Transformers
            services.AddSingleton<ITransform<LookupData, StateLookupData>, StateLookupDataTransformer>();
            services.AddSingleton<ITransform<LookupData, YesNoLookupData>, YesNoLookupDataTransformer>();

            // Data services
            services.AddScoped<IProvideData<LookupData>, LookupDataProvider>();
            services.AddScoped<IProvideCachedData<LookupData>, GenericCachedDataProvider<LookupData>>();
            services.AddScoped<IProvideData<StateLookupData>, GenericTransformDataProvider<IProvideCachedData<LookupData>, LookupData, StateLookupData>>();
            services.AddScoped<IProvideData<YesNoLookupData>, GenericTransformDataProvider<IProvideCachedData<LookupData>, LookupData, YesNoLookupData>>();
            services.AddScoped<IProvideData<StateLookupData>, GenericTransformDataProvider<IProvideCachedData<LookupData>, LookupData, StateLookupData>>();
            services.AddScoped<IProvideCachedData<YesNoLookupData>, GenericCachedKeyedDataProvider<YesNoLookupData>>();
            services.AddScoped<IProvideCachedData<StateLookupData>, GenericCachedKeyedDataProvider<StateLookupData>>();
            services.AddScoped<IProvideKeyedData, GenericCachedKeyedDataProvider<YesNoLookupData>>();
            services.AddScoped<IProvideKeyedData, GenericCachedKeyedDataProvider<StateLookupData>>();

            // Dto Transformers
            services.AddSingleton<ITransform<MyCommonImpl, SomeSpecificDefinition>, CommonToSpecificTransformer>();

            //Transformaion Service
            services.AddSingleton<ITransformationService<MyCommonImpl, SomeSpecificDefinition>, TransformationService<MyCommonImpl, SomeSpecificDefinition>>();

            //Startup actions
            services.AddScoped<IHaveStartupActions, GenericCachedDataProvider<LookupData>>();
            services.AddScoped<IHaveStartupActions, GenericCachedDataProvider<YesNoLookupData>>();
            services.AddScoped<IHaveStartupActions, GenericCachedDataProvider<StateLookupData>>();
        }
    }
}
