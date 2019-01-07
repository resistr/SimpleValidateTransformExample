using System.Collections.Generic;
using System.Linq;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework
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
        public static IReadOnlyDictionary<object, object> ToReadOnlyDictionary(this IEnumerable<IHaveKeyValue> keyedValues)
            => keyedValues.ToDictionary(k => k.GetKey(), v => v.GetValue());

        /// <summary>
        /// Converts a collection of <see cref="KeyValuePair{TKey, TValue}"/> into an <see cref="IReadOnlyDictionary{TKey, TValue}"/>.
        /// </summary>
        /// <typeparam name="TKey">The key type.</typeparam>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <param name="keyedValues">The collection of <see cref="KeyValuePair{TKey, TValue}"/> to convert.</param>
        /// <returns>The converted <see cref="IReadOnlyDictionary{TKey, TValue}"/>.</returns>
        public static IReadOnlyDictionary<TKey, TValue> ToTypedReadOnlyDictionary<TKey, TValue>(this IEnumerable<IHaveKeyValue<TKey, TValue>> keyedValues)
            => keyedValues.ToDictionary(k => k.Key, v => v.Value);
    }
}
