using MarauderMap.Solutions;
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
        private const string DataSourceKey = "data source=";
        private readonly ICurrentSolution _currentSolution;

        public ConnectionStringResolver(
            IOptionsSnapshot<AbpDbConnectionOptions> options,
            ICurrentSolution currentSolution)
            : base(options)
        {
            _currentSolution = currentSolution;
        }

        [Obsolete]
        public override string Resolve(string connectionStringName = null)
        {
            var original = base.Resolve();
            if (connectionStringName == MarauderMapConsts.ConnectionStringName)
            {
                return BuildSolutionConnectionString(original);
            }
            return BuildApplicationConnectionString(original);
        }

        public override async Task<string> ResolveAsync(string connectionStringName = null)
        {
            var original = await base.ResolveAsync();
            if (connectionStringName == MarauderMapConsts.ConnectionStringName)
            {
                return BuildSolutionConnectionString(original);
            }
            return BuildApplicationConnectionString(original);
        }

        private string BuildApplicationConnectionString(string original)
        {
            var dataSourceStartIndex = original.IndexOf(DataSourceKey, comparisonType: StringComparison.OrdinalIgnoreCase) + DataSourceKey.Length;
            var dataSourceValue = GetDataSourceValue(original);

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

        private string BuildSolutionConnectionString(string original)
        {
            var dataSourceStartIndex = original.IndexOf(DataSourceKey, comparisonType: StringComparison.OrdinalIgnoreCase) + DataSourceKey.Length;
            var dataSourceValue = GetDataSourceValue(original);

            if (dataSourceValue.Contains(Path.DirectorySeparatorChar) ||
                            !Path.HasExtension(dataSourceValue) ||
                            Path.GetExtension(dataSourceValue) != ".db")
            {
                throw new ConnectionStringInvalidException();
            }
            var dbFilePath = Path.Combine(_currentSolution.Value.RootNode.Path, "MarauderMap").EnsureEndsWith(Path.DirectorySeparatorChar);
            return original.Insert(dataSourceStartIndex, dbFilePath);
        }

        public static string GetDataSourceValue(string connectionString)
        {
            if (!connectionString.Contains(DataSourceKey, StringComparison.OrdinalIgnoreCase))
            {
                throw new ConnectionStringInvalidException();
            }

            var dataSourceStartIndex = connectionString.IndexOf(DataSourceKey, comparisonType: StringComparison.OrdinalIgnoreCase) + DataSourceKey.Length;
            var dataSourceEndIndex = connectionString.IndexOf(';', dataSourceStartIndex + DataSourceKey.Length);
            if (dataSourceEndIndex == -1)
            {
                dataSourceEndIndex = connectionString.Length;
            }
            var dataSourceValue = connectionString.Substring(dataSourceStartIndex, dataSourceEndIndex - dataSourceStartIndex);
            return dataSourceValue;
        }
    }
}
