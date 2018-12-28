using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework
{
    /// <summary>
    /// Common extensions for <see cref="IHaveStartupActions"/>.
    /// </summary>
    public static class StartupActionExtensions
    {
        /// <summary>
        /// Run all startup actions.
        /// </summary>
        /// <param name="startupActions">The startup actions to run.</param>
        public static void Startup(this IEnumerable<IHaveStartupActions> startupActions)
            // run all startup actions asynchronously in parallel. 
            => AsyncHelper.RunSync(() => Task.WhenAll(startupActions.Select(startupAction => startupAction.Startup())));
    }
}
