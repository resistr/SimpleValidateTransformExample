using AutoMapper;
using Framework.Transformation;
using System;

namespace Tool.Framework.Transformation
{
    /// <summary>
    /// A transformation service based on the <see cref="IMapper"/> interface (AutoMapper). 
    /// </summary>
    public class TransformationService : ITransformationService
    {
        /// <summary>
        /// The DI provided <see cref="IMapper"/> mapper.
        /// </summary>
        protected readonly IMapper Mapper;

        /// <summary>
        ///  Initializes a new instance of the <see cref="TransformationService"/> class.
        /// </summary>
        /// <param name="mapper">The provided <see cref="IMapper"/> mapper.</param>
        public TransformationService(IMapper mapper)
            => Mapper = mapper;

        /// <summary>
        /// An indication of if this class can transform between the two types provided. 
        /// </summary>
        /// <param name="source">The type of the soruce object to transform.</param>
        /// <param name="dest">The type of the destination object to transform.</param>
        /// <returns>
        /// True if this transformer can transform between the soruce and destination
        /// types; otherwise false.
        /// </returns>
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

        /// <summary>
        /// Does the actual transformation. 
        /// </summary>
        /// <typeparam name="TDest">The destination type to transform to.</typeparam>
        /// <param name="source">The source object to transform.</param>
        /// <returns>The result of the transformation.</returns>
        /// <exception cref="TransformationException">Wraps any underlying exception that may have occured.</exception>
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
