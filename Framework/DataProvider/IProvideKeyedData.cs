using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.DataProvider
{
    public interface IProvideKeyedData
    {
        Task<IReadOnlyDictionary<object, object>> ToReadOnlyDictionaryAsync(CancellationToken cancellationToken = default);
    }

    public interface IProvideKeyedData<T> : IProvideData<T> where T : class, IProvideKeyedValue { }
}
