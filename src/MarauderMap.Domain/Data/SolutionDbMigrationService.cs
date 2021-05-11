using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace MarauderMap.Data
{
    public class SolutionDbMigrationService : DbMigrationService<ISolutionDbSchemaMigrator>, ISolutionDbMigrationService, ITransientDependency
    {
        public SolutionDbMigrationService(IEnumerable<ISolutionDbSchemaMigrator> migrators)
            : base(migrators)
        {

        }
    }
}
