using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MarauderMap.EntityFrameworkCore
{
    /* This class is needed for EF Core console commands
     * (like Add-Migration and Update-Database commands) */
    public class MarauderMapDbContextFactory : IDesignTimeDbContextFactory<MarauderMapDbContext>
    {
        public MarauderMapDbContext CreateDbContext(string[] args)
        {
            MarauderMapEfCoreEntityExtensionMappings.Configure();

            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<MarauderMapDbContext>()
                .UseSqlite(configuration.GetConnectionString("Default"));

            return new MarauderMapDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../MarauderMap.Desktop/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
