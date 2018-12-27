using AutoMapper;
using Framework.Transformation;
using System;

namespace Tool.Framework.Transformation
{
    public class TransformationService : ITransformationService
    {
        protected readonly IMapper Mapper;

        public TransformationService(IMapper mapper)
            => Mapper = mapper;

        public bool CanTransform(Type source, Type dest)
        {
            try
            {
                Mapper.ConfigurationProvider.AssertConfigurationIsValid(Mapper.ConfigurationProvider.ResolveTypeMap(source, dest));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public TDest Transform<TDest>(object source)
        {
            try
            {
                return Mapper.Map<TDest>(source);
            }
            catch (Exception ex)
            {
                throw new TransformationException("Unable to transform.", source, source?.GetType(), typeof(TDest), ex);
            }
        }
    }
}
