using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CricketApplicationWebPortal.Roles.Dto;
using CricketApplicationWebPortal.Users.Dto;

namespace CricketApplicationWebPortal.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}
