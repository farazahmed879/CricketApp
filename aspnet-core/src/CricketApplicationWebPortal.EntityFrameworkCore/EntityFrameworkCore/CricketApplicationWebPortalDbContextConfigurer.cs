using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CricketApplicationWebPortal.EntityFrameworkCore
{
    public static class CricketApplicationWebPortalDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CricketApplicationWebPortalDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CricketApplicationWebPortalDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
