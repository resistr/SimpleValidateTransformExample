using AutoMapper;
using Library.DataModel;
using System;
using Tool.Framework.Derivation;
using Tool.Framework.Transformation;
using Tool.Library.Dto;

namespace Tool.Library.Transform
{
    /// <summary>
    /// Auto Mapper <see cref="Profile"/> for mapping <see cref="SourceExample"/> to <see cref="DestExample"/>.
    /// </summary>
    public class SourceExampleToDestExampleProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceExampleToDestExampleProfile" /> class.
        /// </summary>
        public SourceExampleToDestExampleProfile()
        {
            // add transformation rules
            CreateMap<SourceExample, DestExample>()
                .ForPath(dest => dest.TestBool, exp => exp.MapFrom(source => bool.Parse(source.TestBool)))
                .ForPath(dest => dest.TestByte, exp => exp.MapFrom(source => byte.Parse(source.TestByte)))
                .ForPath(dest => dest.TestChar, exp => exp.MapFrom(source => char.Parse(source.TestChar)))
                .ForPath(dest => dest.TestDateTime, exp => exp.MapFrom(source => DateTime.Parse(source.TestDateTime)))
                .ForPath(dest => dest.TestDateTimeOffset, exp => exp.MapFrom(source => DateTimeOffset.Parse(source.TestDateTimeOffset)))
                .ForPath(dest => dest.TestDecimal, exp => exp.MapFrom(source => decimal.Parse(source.TestDecimal)))
                .ForPath(dest => dest.TestDouble, exp => exp.MapFrom(source => double.Parse(source.TestDouble)))
                .ForPath(dest => dest.TestFloat, exp => exp.MapFrom(source => float.Parse(source.TestFloat)))
                .ForPath(dest => dest.TestGuid, exp => exp.MapFrom(source => Guid.Parse(source.TestGuid)))
                .ForPath(dest => dest.TestInt16, exp => exp.MapFrom(source => short.Parse(source.TestInt16)))
                .ForPath(dest => dest.TestInt32, exp => exp.MapFrom(source => int.Parse(source.TestInt32)))
                .ForPath(dest => dest.TestInt64, exp => exp.MapFrom(source => long.Parse(source.TestInt64)))
                .ForPath(dest => dest.TestSbyte, exp => exp.MapFrom(source => sbyte.Parse(source.TestSbyte)))
                .ForPath(dest => dest.TestSingle, exp => exp.MapFrom(source => Single.Parse(source.TestSingle)))
                .ForPath(dest => dest.TestTimeSpan, exp => exp.MapFrom(source => TimeSpan.Parse(source.TestTimeSpan)))
                .ForPath(dest => dest.TestUint16, exp => exp.MapFrom(source => ushort.Parse(source.TestUint16)))
                .ForPath(dest => dest.TestUint32, exp => exp.MapFrom(source => uint.Parse(source.TestUint32)))
                .ForPath(dest => dest.TestUint64, exp => exp.MapFrom(source => ulong.Parse(source.TestUint64)))

                // do derivation
                .ForMember(dest => dest.TestDeriveAddedValue, exp => exp.MapFrom((source, dest) => dest.TestInt16 + dest.TestInt32))
                .ForMember(dest => dest.TestDeriveStringToBool, exp => exp.ConvertUsing<KeyedDataValueConverter<string, YesNoLookupData, string>, string>(src => src.TestString));
        }
    }
}
