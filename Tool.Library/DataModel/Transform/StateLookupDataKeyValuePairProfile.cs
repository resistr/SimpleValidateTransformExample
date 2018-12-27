using AutoMapper;
using Library.DataModel;
using System.Collections.Generic;

namespace Tool.Library.DataModel.Transform
{
    /// <summary>
    /// Auto Mapper <see cref="Profile"/> for mapping <see cref="StateLookupData"/> to <see cref="KeyValuePair{TKey, TValue}"/>.
    /// </summary>
    public class StateLookupDataKeyValuePairProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StateLookupDataKeyValuePairProfile" /> class.
        /// </summary>
        public StateLookupDataKeyValuePairProfile()
        {
            // add transformation rules
            CreateMap<StateLookupData, KeyValuePair<string, StateLookupData>>()
                // use a constructor transform
                .ConstructUsing(source => new KeyValuePair<string, StateLookupData>(source.Name, source));
        }
    }
}
