using AutoMapper;
using Library.DataModel;
using System.Collections.Generic;
using Tool.Library.Dto;

namespace Tool.Library.DataModel.Transform
{
    public class StateLookupDataKeyValuePairProfile : Profile
    {
        public StateLookupDataKeyValuePairProfile()
        {
            CreateMap<StateLookupData, KeyValuePair<string, StateLookupData>>()
                .ConstructUsing(source => new KeyValuePair<string, StateLookupData>(source.Name, source));
        }
    }
}
