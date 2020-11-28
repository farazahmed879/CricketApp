using System.Threading.Tasks;
using CricketApplicationWebPortal.Configuration.Dto;

namespace CricketApplicationWebPortal.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
