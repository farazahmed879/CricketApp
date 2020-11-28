using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CricketApplicationWebPortal.Configuration.Dto;

namespace CricketApplicationWebPortal.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CricketApplicationWebPortalAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
