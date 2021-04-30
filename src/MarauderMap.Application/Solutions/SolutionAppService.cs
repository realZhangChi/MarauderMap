using System.Threading.Tasks;

namespace MarauderMap.Solutions
{
    public class SolutionAppService : MarauderMapAppService, ISolutionAppService
    {
        protected SolutionManager SolutionManager => LazyServiceProvider.LazyGetRequiredService<SolutionManager>();

        public async Task<SolutionDto> SetPathAsync(string fullPath)
        {
            var solution = await SolutionManager.SetSolutionAsync(fullPath);
            return ObjectMapper.Map<Solution, SolutionDto>(solution);
        }
    }
}
