using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CricketApplicationWebPortal.Configuration;
using CricketApplicationWebPortal.Web;

namespace CricketApplicationWebPortal.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CricketApplicationWebPortalDbContextFactory : IDesignTimeDbContextFactory<CricketApplicationWebPortalDbContext>
    {
        public CricketApplicationWebPortalDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CricketApplicationWebPortalDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CricketApplicationWebPortalDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CricketApplicationWebPortalConsts.ConnectionStringName));

            return new CricketApplicationWebPortalDbContext(builder.Options);
        }
    }
}
