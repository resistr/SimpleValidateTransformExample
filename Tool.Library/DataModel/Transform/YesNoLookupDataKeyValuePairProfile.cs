using AutoMapper;
using Library.DataModel;
using System.Collections.Generic;

namespace Tool.Library.DataModel.Transform
{
    public class YesNoLookupDataKeyValuePairProfile : Profile
    {
        public YesNoLookupDataKeyValuePairProfile()
        {
            CreateMap<YesNoLookupData, KeyValuePair<string, YesNoLookupData>>()
                .ConstructUsing(source => new KeyValuePair<string, YesNoLookupData>(source.Name, source));
        }
    }
}
