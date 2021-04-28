using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapDomainModule),
        typeof(MarauderMapApplicationContractsModule)
        )]
    public class MarauderMapApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<MarauderMapApplicationModule>();
            });
        }
    }
}
