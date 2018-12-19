using Framework.Derivation;
using Framework.Transformation;
using Framework.Validation;
using Library.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        protected readonly ITransformationService<MyCommonImpl, SomeSpecificDefinition> TransformationService;
        protected readonly IDerivationService DerivationService;
        protected readonly IValidationService ValidationService;

        public ConversionController(
            ITransformationService<MyCommonImpl, SomeSpecificDefinition> transformationService,
            IDerivationService derivationService,
            IValidationService validationService)
        {
            TransformationService = transformationService;
            DerivationService = derivationService;
            ValidationService = validationService; 
        }

        [HttpGet]
        [Produces("application/xml")]
        public MyCommonImpl Get()
            => new MyCommonImpl
            {
                TestDecimal = "1.14",
                TestChar = "X",
                TestFloat = "4.11",
                TestDouble = "44.88",
                TestByte = "8",
                TestSbyte = "-8",
                TestBool = "true",
                TestInt16 = "-111",
                TestInt32 = "-222",
                TestInt64 = "-333",
                TestUint16 = "111",
                TestUint32 = "222",
                TestUint64 = "333",
                TestSingle = "-.000001",
                TestString = "Yes",
                TestDateTime = "01/01/1900",
                TestDateTimeOffset = "12/31/9999",
                TestGuid = "3676f35a-43dc-4001-baed-6e198e28898f",
                TestTimeSpan = "00:00:15"
            };

        // POST api/values
        [HttpPost]
        [Produces("application/xml")]
        public SomeSpecificDefinition Post([FromBody] MyCommonImpl source)
        {
            var dest = TransformationService.Transform(source);
            DerivationService.Derive(dest);
            ValidationService.Validate(dest);
            return dest;
        }
    }
}
