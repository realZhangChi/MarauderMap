using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace MarauderMap.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class MarauderMapBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "MarauderMap";
    }
}
