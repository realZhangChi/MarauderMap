using Volo.Abp;
using Volo.Abp.Modularity;

namespace MarauderMap.Blazor.Host
{
    [DependsOn(
        typeof(MarauderMapBlazorModule)
    )]
    public class MarauderMapBlazorHostModule : AbpModule
    {
    }
}
