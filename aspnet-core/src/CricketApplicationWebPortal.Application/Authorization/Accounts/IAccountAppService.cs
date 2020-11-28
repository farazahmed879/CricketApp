using System.Threading.Tasks;
using Abp.Application.Services;
using CricketApplicationWebPortal.Authorization.Accounts.Dto;

namespace CricketApplicationWebPortal.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
