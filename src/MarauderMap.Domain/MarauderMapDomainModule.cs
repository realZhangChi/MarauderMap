using MarauderMap.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapDomainSharedModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpAuditLoggingDomainModule)
    )]
    public class MarauderMapDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = MultiTenancyConsts.IsEnabled;
            });
        }
    }
}
