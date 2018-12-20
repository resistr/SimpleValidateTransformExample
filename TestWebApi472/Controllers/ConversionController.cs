﻿using Framework.Derivation;
using Framework.Transformation;
using Framework.Validation;
using Library.Dto;
using System.Web.Http;

namespace TestWebApi472.Controllers
{
    /// <summary>
    /// The tester conversion controller. 
    /// </summary>
    public class ConversionController : ApiController
    {
        protected readonly ITransformationService<MyCommonImpl, SomeSpecificDefinition> TransformationService;
        protected readonly IDerivationService DerivationService;
        protected readonly IValidationService ValidationService;

        /// <summary>
        /// Initializes a new instance of theTestWebApi472.Controllers.ConversionController class.
        /// </summary>
        /// <param name="transformationService">The transformation service to test.</param>
        /// <param name="derivationService">The derivation service to test.</param>
        /// <param name="validationService">The validation service to test.</param>
        public ConversionController(
            ITransformationService<MyCommonImpl, SomeSpecificDefinition> transformationService,
            IDerivationService derivationService,
            IValidationService validationService)
        {
            TransformationService = transformationService;
            DerivationService = derivationService;
            ValidationService = validationService;
        }

        /// <summary>
        /// HttpGet: Get an example of MyCommonImpl.
        /// </summary>
        /// <returns>A fully populated and valid MyCommonImpl.</returns>
        [HttpGet]
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

        /// <summary>
        /// HttpPost: Test the transformation, validation and derivation services. 
        /// </summary>
        /// <param name="source">The <see cref="MyCommonImpl"/> to test.</param>
        /// <returns>The resulting <see cref="SomeSpecificDefinition"/></returns>
        /// <exception cref="DerivationException">If there is an error in the derivation process.</exception>
        /// <exception cref="ValidationException">If there is an error in the validation process.</exception>
        [HttpPost]
        public SomeSpecificDefinition Post([FromBody] MyCommonImpl source)
        {
            var dest = TransformationService.Transform(source);
            DerivationService.Derive(dest);
            ValidationService.Validate(dest);
            return dest;
        }
    }
}