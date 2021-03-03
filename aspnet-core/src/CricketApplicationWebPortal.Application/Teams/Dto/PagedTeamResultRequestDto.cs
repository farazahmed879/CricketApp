using Abp.Application.Services.Dto;

namespace CricketApplicationWebPortal.Roles.Dto
{
    public class PagedTeamResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public int? TenantId { get; set; }
    }
}

