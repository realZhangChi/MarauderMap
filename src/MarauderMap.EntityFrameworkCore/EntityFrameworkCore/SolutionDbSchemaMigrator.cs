using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MarauderMap.Data;
using Volo.Abp.DependencyInjection;
using System.IO;

namespace MarauderMap.EntityFrameworkCore
{
    public class SolutionDbSchemaMigrator
        : ISolutionDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public SolutionDbSchemaMigrator(
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

            var database = _serviceProvider
                .GetRequiredService<MarauderMapDbContext>()
                .Database;
            var dataSource = ConnectionStringResolver.GetDataSourceValue(database.GetConnectionString());
            var dbPath = Path.GetDirectoryName(dataSource);
            if (!Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }
            await database.MigrateAsync();
        }
    }
}