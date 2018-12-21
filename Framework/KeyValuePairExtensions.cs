using Framework.DataProvider;
using System.Collections.Generic;
using System.Linq;

namespace Framework
{
    /// <summary>
    /// Common extensions for <see cref="KeyValuePair"/>.
    /// </summary>
    public static class KeyValuePairExtensions
    {
        /// <summary>
        /// Converts a collection of <see cref="KeyValuePair{TKey, TValue}"/> into an <see cref="IReadOnlyDictionary{object, IProvideValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="keyedValues">The collection of <see cref="KeyValuePair{TKey, TValue}"/> to convert.</param>
        /// <returns>The converted <see cref="IReadOnlyDictionary{object, object}"/>.</returns>
        public static IReadOnlyDictionary<object, IProvideValue> ToValueReadOnlyDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> keyedValues)
            where TValue : IProvideValue
            => keyedValues.ToDictionary(k => k.Key as object, v => v.Value as IProvideValue);

        /// <summary>
        /// Converts a collection of <see cref="KeyValuePair{TKey, TValue}"/> into an <see cref="IReadOnlyDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="keyedValues">The collection of <see cref="KeyValuePair{TKey, TValue}"/> to convert.</param>
        /// <returns>The converted <see cref="IReadOnlyDictionary{TKey, TValue}"/>.</returns>
        public static IReadOnlyDictionary<TKey, TValue> ToTypedReadOnlyDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> keyedValues)
            => keyedValues.ToDictionary(k => k.Key, v => v.Value);
    }
}
