using System.Threading.Tasks;
using Abp.Application.Services;
using CricketApplicationWebPortal.Sessions.Dto;

namespace CricketApplicationWebPortal.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
