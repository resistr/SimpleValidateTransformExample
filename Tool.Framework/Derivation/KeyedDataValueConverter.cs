using AutoMapper;
using Framework.Async;
using Framework.DataProvider;

namespace Tool.Framework.Derivation
{
    /// <summary>
    /// A <see cref="IValueConverter{TSourceMember, TDestinationMember}"/> for <see cref="IProvideKeyedData{TKey, TValue}"/>.
    /// Converts key to value.
    /// </summary>
    /// <typeparam name="TSourceMember">The type of the source data; also the type of the key.</typeparam>
    /// <typeparam name="TValue">
    /// The type of the value for the keyed data provider.
    /// Constrained to <see cref="IProvideValue{TDestinationMember}"/>
    /// </typeparam>
    /// <typeparam name="TDestinationMember">The type of the destination data.</typeparam>
    public class KeyedDataValueConverter<TSourceMember, TValue, TDestinationMember>
        : IValueConverter<TSourceMember, TDestinationMember>
        where TValue : IProvideValue<TDestinationMember>
    {
        /// <summary>
        /// The DI provided <see cref="IProvideKeyedData{TKey, TValue}"/> keyed data provider.
        /// </summary>
        protected readonly IProvideKeyedData<TSourceMember, TValue> KeyedDataProvider;

        /// <summary>
        ///  Initializes a new instance of the <see cref="KeyedDataValueConverter{TSourceMember, TValue, TDestinationMember}"/> class.
        /// </summary>
        /// <param name="keyedDataProvider">The <see cref="IProvideKeyedData{TKey, TValue}"/> keyed data provider.</param>
        public KeyedDataValueConverter(IProvideKeyedData<TSourceMember, TValue> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        /// <summary>
        /// Perform conversion from source member value to destination member value.
        /// </summary>
        /// <param name="sourceMember">Source member object.</param>
        /// <param name="context">Resolution context.</param>
        /// <returns>Destination member value.</returns>
        public TDestinationMember Convert(TSourceMember sourceMember, ResolutionContext context)
            => AsyncHelper.RunSync(() => KeyedDataProvider.GetTypedReadOnlyDictionaryAsync(default))[sourceMember].Value;
    }
}
