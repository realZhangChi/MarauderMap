using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace MarauderMap.EntityFrameworkCore
{
    public static class MarauderMapDbContextModelCreatingExtensions
    {
        public static void ConfigureMarauderMap(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MarauderMapConsts.DbTablePrefix + "YourEntities", MarauderMapConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}