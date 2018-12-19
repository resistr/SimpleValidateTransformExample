using Framework.Transformation;
using Library.Dto;
using System;

namespace Library.Transform
{
    public class CommonToSpecificTransformer : TransformerBase<MyCommonImpl, SomeSpecificDefinition>
    {
        public override SomeSpecificDefinition Transform(MyCommonImpl source)
            => new SomeSpecificDefinition
            {
                TestBool = bool.Parse(source.TestBool),
                TestByte = byte.Parse(source.TestByte),
                TestChar = char.Parse(source.TestChar),
                TestDateTime = DateTime.Parse(source.TestDateTime),
                TestDateTimeOffset = DateTimeOffset.Parse(source.TestDateTimeOffset),
                TestDecimal = decimal.Parse(source.TestDecimal),
                TestDouble = double.Parse(source.TestDouble),
                TestFloat = float.Parse(source.TestFloat),
                TestGuid = Guid.Parse(source.TestGuid),
                TestInt16 = Int16.Parse(source.TestInt16),
                TestInt32 = int.Parse(source.TestInt32),
                TestInt64 = Int64.Parse(source.TestInt64),
                TestSbyte = sbyte.Parse(source.TestSbyte),
                TestSingle = Single.Parse(source.TestSingle),
                TestString = source.TestString,
                TestTimeSpan = TimeSpan.Parse(source.TestTimeSpan),
                TestUint16 = UInt16.Parse(source.TestUint16),
                TestUint32 = UInt32.Parse(source.TestUint32),
                TestUint64 = UInt64.Parse(source.TestUint64),
                TestDeriveStringToBool = source.TestString
            };
    }
}
