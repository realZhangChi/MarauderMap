using MarauderMap.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace MarauderMap.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(MarauderMapEntityFrameworkCoreDbMigrationsModule),
        typeof(MarauderMapApplicationContractsModule)
        )]
    public class MarauderMapDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
