using Framework.Transformation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    public class GenericTransformDataProvider<TDataProvider, TSource, TDest> : IProvideData<TDest>
        where TDataProvider : class, IProvideData<TSource>
        where TSource : class
        where TDest : class
    {
        protected readonly ITransform<TSource, TDest> DataTransformer;
        protected readonly IProvideData<TSource> DataProvider;

        public GenericTransformDataProvider(ITransform<TSource, TDest> dataTransformer, TDataProvider dataProvider)
        {
            DataTransformer = dataTransformer;
            DataProvider = dataProvider;
        }

        public virtual async Task<IEnumerable<TDest>> GetAllAsync(CancellationToken cancellationToken = default)
            => DataTransformer.Transform(await DataProvider.GetAllAsync(cancellationToken));
    }
}
