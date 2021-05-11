using MarauderMap.Solutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MarauderMap.EntityFrameworkCore.EntityConfigurations.Solutions
{
    class ProjectEntityTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable(MarauderMapConsts.DbTablePrefix + "Projects", MarauderMapConsts.DbSchema);
            builder.ConfigureByConvention();
        }
    }
}
