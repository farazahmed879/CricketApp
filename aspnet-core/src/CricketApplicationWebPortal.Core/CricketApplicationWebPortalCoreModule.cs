using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Timing;
using Abp.Zero;
using Abp.Zero.Configuration;
using CricketApplicationWebPortal.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Users;
using CricketApplicationWebPortal.Configuration;
using CricketApplicationWebPortal.Localization;
using CricketApplicationWebPortal.MultiTenancy;
using CricketApplicationWebPortal.Timing;

namespace CricketApplicationWebPortal
{
    [DependsOn(typeof(AbpZeroCoreModule))]
    public class CricketApplicationWebPortalCoreModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Auditing.IsEnabledForAnonymousUsers = true;

            // Declare entity types
            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            Configuration.Modules.Zero().EntityTypes.User = typeof(User);

            CricketApplicationWebPortalLocalizationConfigurer.Configure(Configuration.Localization);

            // Enable this line to create a multi-tenant application.
            Configuration.MultiTenancy.IsEnabled = CricketApplicationWebPortalConsts.MultiTenancyEnabled;

            // Configure roles
            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);

            Configuration.Settings.Providers.Add<AppSettingProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CricketApplicationWebPortalCoreModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            IocManager.Resolve<AppTimes>().StartupTime = Clock.Now;
        }
    }
}
