using MarauderMap.Data;
using System.Threading.Tasks;

namespace MarauderMap.Solutions
{
    public class SolutionAppService : MarauderMapAppService, ISolutionAppService
    {
        protected SolutionManager SolutionManager => LazyServiceProvider.LazyGetRequiredService<SolutionManager>();
        protected ISolutionDbSchemaMigrator Migrator => LazyServiceProvider.LazyGetRequiredService<ISolutionDbSchemaMigrator>();

        public async Task<SolutionDto> SetPathAsync(string fullPath)
        {
            var solution = await SolutionManager.SetSolutionAsync(fullPath);
            await Migrator.MigrateAsync();
            return ObjectMapper.Map<SolutionTree, SolutionDto>(solution);
        }
    }
}
