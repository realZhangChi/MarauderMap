using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace MarauderMap.EntityFrameworkCore
{
    [DependsOn(
        typeof(MarauderMapEntityFrameworkCoreModule)
        )]
    public class MarauderMapEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<MarauderMapMigrationsDbContext>();
        }
    }
}
