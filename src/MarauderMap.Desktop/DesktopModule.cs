using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace MarauderMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreModule),
        typeof(MarauderMapApplicationModule)
        )]
    public class DesktopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<MainWindow>();
            context.Services.AddBlazorWebView();
        }
    }
}
