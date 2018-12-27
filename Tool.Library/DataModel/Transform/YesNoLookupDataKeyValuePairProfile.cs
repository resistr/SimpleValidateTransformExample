using AutoMapper;
using Library.DataModel;
using System.Collections.Generic;

namespace Tool.Library.DataModel.Transform
{
    /// <summary>
    /// Auto Mapper <see cref="Profile"/> for mapping <see cref="YesNoLookupData"/> to <see cref="KeyValuePair{TKey, TValue}"/>.
    /// </summary>
    public class YesNoLookupDataKeyValuePairProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YesNoLookupDataKeyValuePairProfile" /> class.
        /// </summary>
        public YesNoLookupDataKeyValuePairProfile()
        {
            // add transformation rules
            CreateMap<YesNoLookupData, KeyValuePair<string, YesNoLookupData>>()
                // use a constructor transform
                .ConstructUsing(source => new KeyValuePair<string, YesNoLookupData>(source.Name, source));
        }
    }
}
