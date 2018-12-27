using System.Runtime.Serialization;

namespace Tool.Library.Dto
{
    /// <summary>
    /// An example source DTO object.
    /// </summary>
    [DataContract]
    public class SourceExample
    {
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestBool))]
        public string TestBool { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestGuid))]
        public string TestGuid { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSbyte))]
        public string TestSbyte { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt16))]
        public string TestInt16 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestString))]
        public string TestString { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint32))]
        public string TestUint32 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestChar))]
        public string TestChar { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt64))]
        public string TestInt64 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt32))]
        public string TestInt32 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint64))]
        public string TestUint64 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestFloat))]
        public string TestFloat { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSingle))]
        public string TestSingle { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTimeOffset))]
        public string TestDateTimeOffset { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint16))]
        public string TestUint16 { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDouble))]
        public string TestDouble { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTime))]
        public string TestDateTime { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestTimeSpan))]
        public string TestTimeSpan { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestByte))]
        public string TestByte { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDecimal))]
        public string TestDecimal { get; set; }
    }
}
