using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CricketApplicationWebPortal.EntityFrameworkCore;
using CricketApplicationWebPortal.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace CricketApplicationWebPortal.Web.Tests
{
    [DependsOn(
        typeof(CricketApplicationWebPortalWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class CricketApplicationWebPortalWebTestModule : AbpModule
    {
        public CricketApplicationWebPortalWebTestModule(CricketApplicationWebPortalEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CricketApplicationWebPortalWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(CricketApplicationWebPortalWebMvcModule).Assembly);
        }
    }
}