using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.Tests
{
    [TestClass]
    public class StartupActionExtensionsTests
    {
        protected readonly ICollection<Mock<IHaveStartupActions>> Mocks = new HashSet<Mock<IHaveStartupActions>>();

        public StartupActionExtensionsTests()
        {
            Mocks.CreateMock(() => new Mock<IHaveStartupActions>());
            Mocks.CreateMock(() => new Mock<IHaveStartupActions>());
        }
        
        [TestMethod]
        public void RunsStartUpActions()
        {
            Mocks.ToObjects().Startup();
            Mocks.All(item => item.Verify(action => action.Startup(It.IsAny<CancellationToken>()), Times.Once));
            Mocks.VerifyNoOtherCalls();
            Mocks.Reset();
        }
    }
}
