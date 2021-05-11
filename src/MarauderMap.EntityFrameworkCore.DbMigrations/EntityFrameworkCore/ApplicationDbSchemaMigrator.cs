using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MarauderMap.Data;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.EntityFrameworkCore
{
    public class ApplicationDbSchemaMigrator
        : IApplicationDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public ApplicationDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the MarauderMapMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<MarauderMapMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}