using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CricketApplicationWebPortal.Controllers
{
    public abstract class CricketApplicationWebPortalControllerBase: AbpController
    {
        protected CricketApplicationWebPortalControllerBase()
        {
            LocalizationSourceName = CricketApplicationWebPortalConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
