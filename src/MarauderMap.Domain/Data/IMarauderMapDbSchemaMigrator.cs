using System.Threading.Tasks;

namespace MarauderMap.Data
{
    public interface IMarauderMapDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
