using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapDomainSharedModule),
        typeof(AbpObjectExtendingModule)
    )]
    public class MarauderMapApplicationContractsModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MarauderMapDtoExtensions.Configure();
        }
    }
}
