using Volo.Abp.Modularity;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapApplicationModule),
        typeof(MarauderMapDomainTestModule)
        )]
    public class MarauderMapApplicationTestModule : AbpModule
    {

    }
}