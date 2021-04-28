using Localization.Resources.AbpUi;
using MarauderMap.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace MarauderMap
{
    [DependsOn(
        typeof(MarauderMapApplicationContractsModule)
        )]
    public class MarauderMapHttpApiModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            ConfigureLocalization();
        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<MarauderMapResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
        }
    }
}
