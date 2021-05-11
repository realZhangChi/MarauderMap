using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Data
{
    public class ApplicationDbMigrationService : DbMigrationService<IApplicationDbSchemaMigrator>, IApplicationDbMigrationService, ITransientDependency
    {
        public ApplicationDbMigrationService(IEnumerable<IApplicationDbSchemaMigrator> migrators)
            : base(migrators)
        {

        }
    }
}
