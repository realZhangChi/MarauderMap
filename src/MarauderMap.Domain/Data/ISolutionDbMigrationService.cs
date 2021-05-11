using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarauderMap.Data
{
    public interface IApplicationDbMigrationService : IDbMigrationService<IApplicationDbSchemaMigrator>
    {
    }
}
