using Abp.Application.Services.Dto;

namespace CricketApplicationWebPortal.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

