using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Data
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(IConnectionStringResolver))]
    public class ConnectionStringResolver
        : DefaultConnectionStringResolver
    {
        public ConnectionStringResolver(IOptionsSnapshot<AbpDbConnectionOptions> options)
            : base(options)
        {
        }

        [Obsolete]
        public override string Resolve(string connectionStringName = null)
        {
            var original = base.Resolve(connectionStringName);
            return BuildConnectionString(original);
        }

        public override async Task<string> ResolveAsync(string connectionStringName = null)
        {
            var original = await base.ResolveAsync(connectionStringName);
            return BuildConnectionString(original);
        }

        private static string BuildConnectionString(string original)
        {
            var dataSourceKey = "data source=";
            if (!original.Contains(dataSourceKey, StringComparison.OrdinalIgnoreCase))
            {
                throw new ConnectionStringInvalidException();
            }

            var dataSourceStartIndex = original.IndexOf(dataSourceKey, comparisonType: StringComparison.OrdinalIgnoreCase) + dataSourceKey.Length;
            var dataSourceEndIndex = original.IndexOf(';', dataSourceStartIndex + dataSourceKey.Length);
            if (dataSourceEndIndex == -1)
            {
                dataSourceEndIndex = original.Length;
            }
            var dataSourceValue = original.Substring(dataSourceStartIndex, dataSourceEndIndex - dataSourceStartIndex);

            if (dataSourceValue.Contains(Path.DirectorySeparatorChar) ||
                            !Path.HasExtension(dataSourceValue) ||
                            Path.GetExtension(dataSourceValue) != ".db")
            {
                throw new ConnectionStringInvalidException();
            }
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dbFilePath = Path.Combine(appDataPath, "MarauderMap").EnsureEndsWith(Path.DirectorySeparatorChar);
            return original.Insert(dataSourceStartIndex, dbFilePath);
        }
    }
}
