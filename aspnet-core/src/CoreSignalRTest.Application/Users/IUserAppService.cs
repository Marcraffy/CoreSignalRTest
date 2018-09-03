using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreSignalRTest.Roles.Dto;
using CoreSignalRTest.Users.Dto;

namespace CoreSignalRTest.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
