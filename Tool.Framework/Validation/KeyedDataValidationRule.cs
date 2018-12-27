using Framework.DataProvider;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tool.Framework.Validation
{
    public class KeyedDataValidationRule<TKey, TValue>
        where TValue : IProvideValue
    {
        protected readonly IProvideKeyedData<TKey, TValue> KeyedDataProvider;

        public KeyedDataValidationRule(IProvideKeyedData<TKey, TValue> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        public async Task<bool> ValidateKeyAsync(TKey source, CancellationToken cancellationToken = default)
            => (await KeyedDataProvider.GetTypedReadOnlyDictionaryAsync()).ContainsKey(source);

        public async Task<bool> ValidateValueAsync(object source, CancellationToken cancellationToken = default)
            => (await KeyedDataProvider.GetTypedReadOnlyDictionaryAsync()).Values.Any(value => value.GetValue() == source);
    }
}
