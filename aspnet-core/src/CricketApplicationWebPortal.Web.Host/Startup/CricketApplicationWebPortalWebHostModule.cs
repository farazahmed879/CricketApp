using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CricketApplicationWebPortal.Configuration;

namespace CricketApplicationWebPortal.Web.Host.Startup
{
    [DependsOn(
       typeof(CricketApplicationWebPortalWebCoreModule))]
    public class CricketApplicationWebPortalWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CricketApplicationWebPortalWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CricketApplicationWebPortalWebHostModule).GetAssembly());
        }
    }
}
