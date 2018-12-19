using System.Collections.Generic;
using System.Linq;

namespace Framework.DataProvider
{
    public static class ProvideKeyedValueExtensions
    {
        public static IReadOnlyDictionary<object, object> ToReadOnlyDictionary(this IEnumerable<IProvideKeyedValue> keyedValues)
            => keyedValues.ToDictionary(k => k.GetKey(), k => k.GetValue());
    }
}
