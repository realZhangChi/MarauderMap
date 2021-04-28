using Volo.Abp.Modularity;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapApplicationModule)
        )]
    public class MarauderMapApplicationTestModule : AbpModule
    {

    }
}