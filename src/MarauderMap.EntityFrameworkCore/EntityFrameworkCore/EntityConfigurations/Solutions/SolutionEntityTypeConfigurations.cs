using MarauderMap.Solutions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MarauderMap.EntityFrameworkCore.EntityConfigurations
{
    class SolutionEntityTypeConfigurations : IEntityTypeConfiguration<Solution>
    {
        public void Configure(EntityTypeBuilder<Solution> builder)
        {
            builder.ToTable(MarauderMapConsts.DbTablePrefix + "Solutions", MarauderMapConsts.DbSchema);
            builder.ConfigureByConvention();


            var navigation = builder.Metadata.FindNavigation(nameof(Solution.Projects));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
