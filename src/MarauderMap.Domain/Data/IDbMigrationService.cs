﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarauderMap.Data
{
    public interface IDbMigrationService<TMigrator> where TMigrator : IDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}