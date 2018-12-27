using Framework.Transformation;
using Tool.Library.Dto;
using System.Web.Http;

namespace Tool.TestWebApi472.Controllers
{
    /// <summary>
    /// The tester conversion controller. 
    /// </summary>
    public class ConversionController : ApiController
    {
        protected readonly ITransformationService TransformationService;

        /// <summary>
        /// Initializes a new instance of the TestWebApi472.Controllers.ConversionController class.
        /// </summary>
        /// <param name="transformationService">The transformation service to test.</param>
        /// <param name="derivationService">The derivation service to test.</param>
        public ConversionController(ITransformationService transformationService)
            => TransformationService = transformationService;

        /// <summary>
        /// HttpGet: Get an example of SourceExample.
        /// </summary>
        /// <returns>A fully populated and valid SourceExample.</returns>
        [HttpGet]
        public SourceExample Get()
            => new SourceExample
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

        /// <summary>
        /// HttpPost: Test the transformation, validation and derivation services. 
        /// </summary>
        /// <param name="source">The <see cref="SourceExample"/> to test.</param>
        /// <returns>The resulting <see cref="DestExample"/></returns>
        /// <exception cref="TransformationException">If there is an error in the transformation process.</exception>
        /// <exception cref="DerivationException">If there is an error in the derivation process.</exception>
        /// <exception cref="ValidationException">If there is an error in the validation process.</exception>
        [HttpPost]
        public IHttpActionResult Post([FromBody] SourceExample source)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dest = TransformationService.Transform<DestExample>(source);
            if (dest.TestDeriveStringToBool == bool.FalseString)
            {
                dest.TestDeriveStringToBool = null;
            }
            Validate(dest);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(dest);
        }
    }
}