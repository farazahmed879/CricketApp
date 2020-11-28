using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using CricketApplicationWebPortal.EntityFrameworkCore.Seed;

namespace CricketApplicationWebPortal.EntityFrameworkCore
{
    [DependsOn(
        typeof(CricketApplicationWebPortalCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class CricketApplicationWebPortalEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<CricketApplicationWebPortalDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        CricketApplicationWebPortalDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        CricketApplicationWebPortalDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CricketApplicationWebPortalEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
