using MarauderMap.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapEntityFrameworkCoreTestModule)
        )]
    public class MarauderMapDomainTestModule : AbpModule
    {

    }
}