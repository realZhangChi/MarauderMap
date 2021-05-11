using MarauderMap.Data;
using MarauderMap.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.AspNetCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace MarauderMap.Desktop
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreModule),
        typeof(MarauderMapApplicationModule),
        typeof(MarauderMapEntityFrameworkCoreModule),
        typeof(MarauderMapEntityFrameworkCoreDbMigrationsModule)
        )]
    public class DesktopModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<MainWindow>();
            context.Services.AddBlazorWebView();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            base.OnApplicationInitialization(context);

            Migration(context);
        }

        private void Migration(ApplicationInitializationContext context)
        {
            AsyncHelper.RunSync(async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider
                    .GetRequiredService<IApplicationDbMigrationService>()
                    .MigrateAsync();
            });
        }
    }
}
