using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CricketApplicationWebPortal.Authorization;

namespace CricketApplicationWebPortal
{
    [DependsOn(
        typeof(CricketApplicationWebPortalCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CricketApplicationWebPortalApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CricketApplicationWebPortalAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CricketApplicationWebPortalApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
