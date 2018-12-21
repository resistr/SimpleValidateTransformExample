using Framework.Transformation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    /// <summary>
    /// A generic implementation of <see cref="IProvideData{TDest}"/> that uses <see cref="ITransform{TSource, TDest}"/>
    /// To provide transformed data.
    /// </summary>
    /// <typeparam name="TSource">The type of source data to transform.</typeparam>
    /// <typeparam name="TDest">The type of dest data from the transform to provide.</typeparam>
    public class GenericTransformDataProvider<TSource, TDest> : IProvideData<TDest>
    {
        protected readonly ITransform<TSource, TDest> DataTransformer;
        protected readonly IProvideData<TSource> DataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericTransformDataProvider{TSource, TDest}" /> class.
        /// </summary>
        /// <param name="dataTransformer">The transform responsible for transforming the data types.</param>
        /// <param name="dataProvider">The provider responsible for providing the source data.</param>
        public GenericTransformDataProvider(ITransform<TSource, TDest> dataTransformer, IProvideData<TSource> dataProvider)
        {
            DataTransformer = dataTransformer;
            DataProvider = dataProvider;
        }

        /// <summary>
        /// Provides the transformed data from the data provider. 
        /// </summary>
        /// <param name="cancellationToken">The cancellation token used to determine if the asynchronous operation should be cancelled.</param>
        /// <returns>The transformed data from the source.</returns>
        public virtual async Task<IEnumerable<TDest>> GetAllAsync(CancellationToken cancellationToken = default)
            => DataTransformer.Transform(await DataProvider.GetAllAsync(cancellationToken));
    }
}
