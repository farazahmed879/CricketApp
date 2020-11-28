using Abp.Application.Services;
using CricketApplicationWebPortal.MultiTenancy.Dto;

namespace CricketApplicationWebPortal.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

