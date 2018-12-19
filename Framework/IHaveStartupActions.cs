using System.Threading;
using System.Threading.Tasks;

namespace Framework
{
    public interface IHaveStartupActions
    {
        Task Startup(CancellationToken cancellationToken = default);
    }
}
