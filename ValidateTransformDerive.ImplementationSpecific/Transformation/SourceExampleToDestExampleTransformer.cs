using System;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Transformation;
using ValidateTransformDerive.ImplementationSpecific.Dto;

namespace ValidateTransformDerive.ImplementationSpecific.Transform
{
    /// <summary>
    /// Specific implementation of <see cref="ITransform{SourceExample, DestExample}"/>.
    /// </summary>
    public class SourceExampleToDestExampleTransformer : TransformerBase<SourceExample, DestExample>
    {
        /// <summary>
        /// Transforms <see cref="SourceExample"/> to <see cref="DestExample"/>.
        /// </summary>
        /// <param name="source">The source item to transform.</param>
        /// <returns>The transformed item.</returns>
        public override DestExample TransformInternal(SourceExample source)
            => new DestExample
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
                TestTimeSpan = TimeSpan.Parse(source.TestTimeSpan),
                TestUint16 = UInt16.Parse(source.TestUint16),
                TestUint32 = UInt32.Parse(source.TestUint32),
                TestUint64 = UInt64.Parse(source.TestUint64),
            };
    }
}
