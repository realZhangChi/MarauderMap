using System.Threading.Tasks;

namespace MarauderMap.Data
{
    public interface IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
