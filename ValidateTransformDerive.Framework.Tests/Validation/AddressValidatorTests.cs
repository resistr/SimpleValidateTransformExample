using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.Dto;
using ValidateTransformDerive.Framework.Validation;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    [TestClass]
    public class AddressValidatorTests
    {
        protected readonly AddressValidator Validator = new AddressValidator();
        protected static readonly string GuidEmpty = Guid.Empty.ToString();

        [TestMethod]
        public void TestRuleForCity()
            => Validator.StringIsRequired(ex => ex.City, nameof(Address.City));

        [TestMethod]
        public void TestRuleForFirstLine()
            => Validator.StringIsRequired(ex => ex.FirstLine, nameof(Address.FirstLine));

        [TestMethod]
        public void TestRuleForPostalCode()
            => Validator.StringIsRequired(ex => ex.PostalCode, nameof(Address.PostalCode));

        [TestMethod]
        public void TestRuleForState()
            => Validator.StringIsRequired(ex => ex.State, nameof(Address.State));

        [TestMethod]
        public void TestRuleForSecondLine()
        {
            Validator.ShouldNotHaveValidationErrorFor(ex => ex.SecondLine, null as string);
            Validator.ShouldNotHaveValidationErrorFor(ex => ex.SecondLine, string.Empty);
            Validator.ShouldNotHaveValidationErrorFor(ex => ex.SecondLine, nameof(Address.SecondLine));
        }

    }
}
