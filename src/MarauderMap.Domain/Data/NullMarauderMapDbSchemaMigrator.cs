using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Data
{
    /* This is used if database provider does't define
     * IMarauderMapDbSchemaMigrator implementation.
     */
    public class NullMarauderMapDbSchemaMigrator : IMarauderMapDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}