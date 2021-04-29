using System.Threading.Tasks;

namespace MarauderMap.Solution
{
    public class SolutionAppService : MarauderMapAppService, ISolutionAppService
    {
        protected ICurrentSolution CurrentSolution => LazyServiceProvider.LazyGetRequiredService<ICurrentSolution>();

        public Task SetPathAsync(string fullPath)
        {
            return CurrentSolution.SetPathAsync(fullPath);
        }
    }
}
