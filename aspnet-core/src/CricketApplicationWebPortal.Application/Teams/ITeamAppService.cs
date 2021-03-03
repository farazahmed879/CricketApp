using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CricketApplicationWebPortal.Roles.Dto;

namespace CricketApplicationWebPortal.Roles
{
    public interface ITeamAppService : IApplicationService
    {
        Task<ResponseMessagesDto> CreateOrEditAsync(CreateTeamDto model);


        Task<TeamDto> GetById(long id);

        Task<ResponseMessagesDto> DeleteAsync(long id);

        Task<List<TeamDto>> GetAll(long? tenantId);

        Task<PagedResultDto<TeamDto>> GetPaginatedAllAsync(PagedTeamResultRequestDto input);

    }
}
