using MarauderMap.Localization;
using Volo.Abp.AspNetCore.Components;

namespace MarauderMap.Blazor
{
    public abstract class MarauderMapComponentBase : AbpComponentBase
    {
        protected MarauderMapComponentBase()
        {
            LocalizationResource = typeof(MarauderMapResource);
        }
    }
}
