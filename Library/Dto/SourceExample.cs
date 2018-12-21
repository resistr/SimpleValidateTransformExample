using Framework.DataProvider;
using Framework.Validation;
using Library.DataModels;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Dto
{
    /// <summary>
    /// An example source DTO object.
    /// </summary>
    [DataContract]
    public class SourceExample
    {
        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Bool))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestBool))]
        public string TestBool { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Guid))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestGuid))]
        public string TestGuid { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Sbyte))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSbyte))]
        public string TestSbyte { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Short))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt16))]
        public string TestInt16 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.String))]
        [KeyedDataValidation(typeof(IProvideKeyedData<string, YesNoLookupData>))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestString))]
        public string TestString { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.UInt))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint32))]
        public string TestUint32 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Char))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestChar))]
        public string TestChar { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Long))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt64))]
        public string TestInt64 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Int))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt32))]
        public string TestInt32 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ULong))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint64))]
        public string TestUint64 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Float))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestFloat))]
        public string TestFloat { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Float))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSingle))]
        public string TestSingle { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.DateTimeOffset))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTimeOffset))]
        public string TestDateTimeOffset { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.UShort))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint16))]
        public string TestUint16 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Double))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDouble))]
        public string TestDouble { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.DateTime))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTime))]
        public string TestDateTime { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.TimeSpan))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestTimeSpan))]
        public string TestTimeSpan { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Byte))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestByte))]
        public string TestByte { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.Decimal))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDecimal))]
        public string TestDecimal { get; set; }
    }
}
