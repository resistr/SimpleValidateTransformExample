using Framework.DataProvider;
using Library.DataModels;
using Library.Validation;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.Dto
{
    [DataContract]
    [ExternalDataLookupValidation(nameof(TestString), typeof(IProvideCachedData<YesNoLookupData>))]
    public class MyCommonImpl
    {
        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateBool))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestBool))]
        public string TestBool { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestGuid))]
        public string TestGuid { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateSbyte))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSbyte))]
        public string TestSbyte { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateInt16))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt16))]
        public string TestInt16 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateString))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestString))]
        public string TestString { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateUint32))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint32))]
        public string TestUint32 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateChar))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestChar))]
        public string TestChar { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateInt64))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt64))]
        public string TestInt64 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateInt32))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestInt32))]
        public string TestInt32 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateUint64))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint64))]
        public string TestUint64 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateFloat))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestFloat))]
        public string TestFloat { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateSingle))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestSingle))]
        public string TestSingle { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTimeOffset))]
        public string TestDateTimeOffset { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateUint16))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestUint16))]
        public string TestUint16 { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateDouble))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDouble))]
        public string TestDouble { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDateTime))]
        public string TestDateTime { get; set; }

        [Required]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestTimeSpan))]
        public string TestTimeSpan { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateByte))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestByte))]
        public string TestByte { get; set; }

        [Required]
        [CustomValidation(typeof(DataTypeValidations), nameof(DataTypeValidations.ValidateDecimal))]
        [DataMember(EmitDefaultValue = false, IsRequired = false, Name = nameof(TestDecimal))]
        public string TestDecimal { get; set; }
    }
}
