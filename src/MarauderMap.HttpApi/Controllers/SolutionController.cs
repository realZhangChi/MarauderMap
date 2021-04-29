using System.Threading.Tasks;
using MarauderMap.Solution;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace MarauderMap.Controllers
{
    [Controller]
    [Route("api/solution")]
    [RemoteService]
    public class SolutionController : MarauderMapController, ISolutionAppService
    {
        private readonly ISolutionAppService _solutionAppService;

        public SolutionController(ISolutionAppService solutionAppService)
        {
            _solutionAppService = solutionAppService;
        }

        [HttpPost]
        public Task SetPathAsync([FromBody] string fullPath)
        {
            return _solutionAppService.SetPathAsync(fullPath);
        }
    }
}
