using AutoMapper;
using Framework.Async;
using Framework.DataProvider;

namespace Tool.Framework.Transformation
{
    public class KeyedDataValueConverter<TSourceMember, TValue, TDestinationMember>
        : IValueConverter<TSourceMember, TDestinationMember>
        where TValue : IProvideValue<TDestinationMember>
    {
        protected readonly IProvideKeyedData<TSourceMember, TValue> KeyedDataProvider;

        public KeyedDataValueConverter(IProvideKeyedData<TSourceMember, TValue> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        public TDestinationMember Convert(TSourceMember sourceMember, ResolutionContext context)
            => AsyncHelper.RunSync(() => KeyedDataProvider.GetTypedReadOnlyDictionaryAsync(default))[sourceMember].Value;
    }
}
