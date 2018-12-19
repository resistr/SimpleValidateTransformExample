using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework
{
    public static class StartupActionExtensions
    {
        public static void Startup(this IEnumerable<IHaveStartupActions> startupActions)
            => AsyncHelper.RunSync(() => Task.WhenAll(startupActions.Select(startupAction => startupAction.Startup())));
    }
}
