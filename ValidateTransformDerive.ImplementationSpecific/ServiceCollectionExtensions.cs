using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using ValidateTransformDerive.Framework.DataProvider;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Transformation;
using ValidateTransformDerive.Framework.Validation;
using ValidateTransformDerive.ImplementationSpecific.DataModel;
using ValidateTransformDerive.ImplementationSpecific.DataModel.Transform;
using ValidateTransformDerive.ImplementationSpecific.DataProvider;
using ValidateTransformDerive.ImplementationSpecific.Dto;
using ValidateTransformDerive.ImplementationSpecific.Transform;
using ValidateTransformDerive.ImplementationSpecific.Validation;

namespace ValidateTransformDerive.ImplementationSpecific
{
    /// <summary>
    /// Common extensions for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Register client services. 
        /// 
        /// </summary>
        /// <param name="services">The service collection to register the services to.</param>
        public static void AddClientSpecificTransformations(this IServiceCollection services)
        {
            // add any data providers
            services.AddCachedKeyedDataProvider<string, string, YesNoLookupData, YesNoLookupDataProvider, YesNoLookupDataKeyValuePairTransform>();
            services.AddCachedKeyedDataProvider<string, string, StateLookupData, StateLookupDataProvider, StateLookupDataKeyValuePairTransform>();

            // add validation.
            services.AddValidator<Address, AddressValidator>();
            services.AddValidator<SourceExample, Validation.SourceExampleValidator>();
            services.AddValidator<DestExample, DestExampleValidator>();

            // add transformation
            services.AddTransformationService<SourceExample, DestExample, SourceExampleToDestExampleTransformer>();

            // add derivation
            services.AddDerivationService<SourceExample, DestExample, SourceExampleToDestExampleDerivation>();
        }
    }
}
