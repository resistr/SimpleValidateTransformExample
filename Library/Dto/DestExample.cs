using Framework.DataProvider;
using Framework.Derivation;
using Library.DataModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Dto
{
    /// <summary>
    /// A sample dest DTO object.
    /// </summary>
    [DataContract]
    [KeyedDataDerivation(nameof(TestDeriveStringToBool), typeof(IProvideKeyedData<string, YesNoLookupData>))]
    [DataCalculationDerivation(nameof(TestInt16), nameof(TestInt32), nameof(TestDeriveAddedValue))]
    public class DestExample
    {
        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestBool))]
        public bool TestBool { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestGuid))]
        public Guid TestGuid { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSbyte))]
        public SByte TestSbyte { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt16))]
        public Int16 TestInt16 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDeriveAddedValue))]
        public int TestDeriveAddedValue { get; set; }

        [IgnoreDataMember]
        public string TestString { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint32))]
        public UInt32 TestUint32 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestChar))]
        public Char TestChar { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt64))]
        public Int64 TestInt64 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt32))]
        public Int32 TestInt32 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint64))]
        public UInt64 TestUint64 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestFloat))]
        public float TestFloat { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSingle))]
        public Single TestSingle { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDeriveStringToBool))]
        public string TestDeriveStringToBool { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTimeOffset))]
        public DateTimeOffset TestDateTimeOffset { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint16))]
        public UInt16 TestUint16 { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDouble))]
        public Double TestDouble { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTime))]
        public DateTime TestDateTime { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestTimeSpan))]
        public TimeSpan TestTimeSpan { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestByte))]
        public Byte TestByte { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDecimal))]
        public Decimal TestDecimal { get; set; }
    }
}
