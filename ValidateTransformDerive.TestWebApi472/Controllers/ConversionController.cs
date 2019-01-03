using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ValidateTransformDerive.Framework.Derivation;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Transformation;
using ValidateTransformDerive.ImplementationSpecific.Dto;

namespace Tool.TestWebApi472.Controllers
{
    /// <summary>
    /// The tester conversion controller. 
    /// </summary>
    public class ConversionController : ApiController
    {
        protected readonly ITransformationService<SourceExample, DestExample> TransformationService;
        protected readonly IDerivationService<SourceExample, DestExample> DerivationService;

        /// <summary>
        /// Initializes a new instance of the TestWebApi472.Controllers.ConversionController class.
        /// </summary>
        /// <param name="derivationService">The derivation service to test.</param>
        /// <param name="transformationService">The transformation service to test.</param>
        public ConversionController(
            IDerivationService<SourceExample, DestExample> derivationService,
            ITransformationService<SourceExample, DestExample> transformationService
            )
        {
            DerivationService = derivationService;
            TransformationService = transformationService;
        }

        /// <summary>
        /// HttpGet: Get an example of SourceExample.
        /// </summary>
        /// <returns>A fully populated and valid SourceExample.</returns>
        [HttpGet]
        public SourceExample Get()
            => new SourceExample
            {
                Addresses = new[]
                {
                    new Address { City = "city", FirstLine = "first line", PostalCode = "postal code", State = "state" }
                },
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
        [HttpPost]
        [ResponseType(typeof(DestExample))]
        public async Task<IHttpActionResult> Post([FromBody] SourceExample source, CancellationToken cancellationToken = default)
        {
            // 4.7.2 Web API does not automatically reject an invalid request.
            // This must be handled manually in 4.7.2.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // transform the data
            var dest = TransformationService.Transform(source);

            // derive the data
            dest = await DerivationService.Derive(source, dest, cancellationToken);

            // hack put in place for testing post transform validation errors. 
            if (dest.TestDeriveStringToBool == bool.FalseString)
            {
                dest.TestDeriveStringToBool = null;
            }

            // validate the object after transformation.
            Validate(dest);

            // handle post transformation validation errors.
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // return the object post transformation & validation
            return Ok(dest);
        }
    }
}