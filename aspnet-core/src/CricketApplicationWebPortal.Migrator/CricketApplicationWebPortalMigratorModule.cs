using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CricketApplicationWebPortal.Configuration;
using CricketApplicationWebPortal.EntityFrameworkCore;
using CricketApplicationWebPortal.Migrator.DependencyInjection;

namespace CricketApplicationWebPortal.Migrator
{
    [DependsOn(typeof(CricketApplicationWebPortalEntityFrameworkModule))]
    public class CricketApplicationWebPortalMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CricketApplicationWebPortalMigratorModule(CricketApplicationWebPortalEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CricketApplicationWebPortalMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CricketApplicationWebPortalConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CricketApplicationWebPortalMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
