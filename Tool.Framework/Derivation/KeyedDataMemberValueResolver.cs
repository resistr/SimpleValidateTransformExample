using AutoMapper;
using Framework.Async;
using Framework.DataProvider;

namespace Tool.Framework.Derivation
{
    public class KeyedDataMemberValueResolver<TSource, TDest, TKey, TValue> : IMemberValueResolver<TSource, TDest, TKey, TValue>
        where TValue : IProvideValue
    {
        protected readonly IProvideKeyedData<TKey, TValue> KeyedDataProvider;

        public KeyedDataMemberValueResolver(IProvideKeyedData<TKey, TValue> keyedDataProvider)
            => KeyedDataProvider = keyedDataProvider;

        public TValue Resolve(TSource source, TDest destination, TKey sourceMember, TValue destMember, ResolutionContext context)
            => AsyncHelper.RunSync(() => KeyedDataProvider.GetTypedReadOnlyDictionaryAsync())[sourceMember];
    }
}
