using FluentValidation;
using FluentValidation.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
    public class RuleBuilderOptionsExtensionsTests
    {
        public readonly Mock<IRuleBuilderOptions<Address, string>> RuleBuilderOptionsMock 
            = new Mock<IRuleBuilderOptions<Address, string>>();

        public RuleBuilderOptionsExtensionsTests()
        {
            RuleBuilderOptionsMock
                .Setup(builder => builder.Configure(It.IsAny<Action<PropertyRule>>()))
                .Returns(RuleBuilderOptionsMock.Object);
        }

        [TestMethod]
        public void CreateMessageCodeTest()
        {
            RuleBuilderOptionsMock.Object.CreateMessageCode(nameof(CreateMessageCodeTest));
            RuleBuilderOptionsMock
                .Verify(builder => builder.Configure(It.IsAny<Action<PropertyRule>>()), Times.Exactly(2));
            RuleBuilderOptionsMock.VerifyNoOtherCalls();
        }
    }
}
