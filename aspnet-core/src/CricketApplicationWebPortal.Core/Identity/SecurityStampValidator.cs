using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using CricketApplicationWebPortal.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Users;
using CricketApplicationWebPortal.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace CricketApplicationWebPortal.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
