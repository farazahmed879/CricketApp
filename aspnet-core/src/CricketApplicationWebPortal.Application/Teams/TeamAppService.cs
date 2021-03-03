using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using CricketApplicationWebPortal.Authorization;
using CricketApplicationWebPortal.Authorization.Roles;
using CricketApplicationWebPortal.Authorization.Users;
using CricketApplicationWebPortal.Models;
using CricketApplicationWebPortal.Roles.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CricketApplicationWebPortal.Roles
{
    [AbpAuthorize(PermissionNames.Pages_Roles)]
    public class TeamAppService : AbpServiceBase, ITeamAppService
    {
        private readonly IRepository<Team, long> _repository;

        public TeamAppService(IRepository<Team, long> repository)
        {
            _repository = repository;
        }

        public async Task<ResponseMessagesDto> CreateOrEditAsync(CreateTeamDto model)
        {
            ResponseMessagesDto result;
            if (model.Id == 0)
            {
                result = await CreateTeamAsync(model);
            }
            else
            {
                result = await UpdateTeamAsync(model);
            }
            return result;
        }

        private async Task<ResponseMessagesDto> CreateTeamAsync(CreateTeamDto model)
        {

            var result = await _repository.InsertAsync(new Team()
            {
                Address = model.Address,
                Zone = model.Zone,
                Name = model.Name,
                TenantId = model.TenantId

            });


            await UnitOfWorkManager.Current.SaveChangesAsync();

            if (result.Id != 0)
            {
                return new ResponseMessagesDto()
                {
                    Id = result.Id,
                    SuccessMessage = AppConsts.SuccessfullyInserted,
                    Success = true,
                    Error = false,
                };
            }
            return new ResponseMessagesDto()
            {
                Id = 0,
                ErrorMessage = AppConsts.InsertFailure,
                Success = false,
                Error = true,
            };
        }

        private async Task<ResponseMessagesDto> UpdateTeamAsync(CreateTeamDto model)
        {
            var result = await _repository.UpdateAsync(new Team()
            {
                Id = model.Id,
                Address = model.Address,
                Name = model.Name,
                Zone = model.Zone,
                TenantId = model.TenantId
            });

            if (result != null)
            {
                return new ResponseMessagesDto()
                {
                    Id = result.Id,
                    SuccessMessage = AppConsts.SuccessfullyUpdated,
                    Success = true,
                    Error = false,
                };
            }
            return new ResponseMessagesDto()
            {
                Id = 0,
                ErrorMessage = AppConsts.UpdateFailure,
                Success = false,
                Error = true,
            };
        }

        public async Task<TeamDto> GetById(long id)
        {
            var result = await _repository.GetAll()
                .Where(i => i.Id == id)
                .Select(i =>
                new TeamDto()
                {
                    Id = i.Id,
                    Address = i.Address,
                    Zone = i.Zone,
                    Name = i.Name
                })
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<ResponseMessagesDto> DeleteAsync(long id)
        {
            await _repository.DeleteAsync(i => i.Id == id);
            await UnitOfWorkManager.Current.SaveChangesAsync();
            return new ResponseMessagesDto()
            {
                Id = id,
                SuccessMessage = AppConsts.SuccessfullyDeleted,
                Success = true,
                Error = false,
            };
        }

        public async Task<List<TeamDto>> GetAll(long? tenantId)
        {
            var result = await _repository.GetAll()
                .Where(i => i.TenantId == tenantId)
                .Select(i => new TeamDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Zone = i.Zone,
                }).ToListAsync();

            return result;
        }

        public async Task<PagedResultDto<TeamDto>> GetPaginatedAllAsync(PagedTeamResultRequestDto input)
        {
            var filteredShopProducts = _repository.GetAll()
               .Where(i => i.IsDeleted == false && (!input.TenantId.HasValue || i.TenantId == input.TenantId))
                .WhereIf(!string.IsNullOrWhiteSpace(input.Keyword), x => x.Name.Contains(input.Keyword));

            var pagedAndFilteredTeams = filteredShopProducts
                .OrderByDescending(i => i.Id)
                .PageBy(input);

            var totalCount = pagedAndFilteredTeams.Count();

            return new PagedResultDto<TeamDto>(
                totalCount: totalCount,
                items: await pagedAndFilteredTeams.Select(i => new TeamDto()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Address = i.Address,
                    Zone = i.Zone,

                })
                    .ToListAsync());
        }
    }
}

