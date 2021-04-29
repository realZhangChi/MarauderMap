using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace MarauderMap.Solution
{
    public interface ISolutionAppService : IApplicationService
    {
        Task SetPathAsync([NotNull] string fullPath);
    }
}
