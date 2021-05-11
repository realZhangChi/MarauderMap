using MarauderMap.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace MarauderMap
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpLocalizationModule),
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpAuditLoggingDomainSharedModule))]
    public class MarauderMapDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            MarauderMapGlobalFeatureConfigurator.Configure();
            MarauderMapModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<MarauderMapDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<MarauderMapResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/MarauderMap");

                options.DefaultResourceType = typeof(MarauderMapResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("MarauderMap", typeof(MarauderMapResource));
            });
        }
    }
}
