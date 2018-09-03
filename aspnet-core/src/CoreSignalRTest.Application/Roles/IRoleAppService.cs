using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreSignalRTest.Roles.Dto;

namespace CoreSignalRTest.Roles
{
    public interface IRoleAppService : IAsyncCrudAppService<RoleDto, int, PagedResultRequestDto, CreateRoleDto, RoleDto>
    {
        Task<ListResultDto<PermissionDto>> GetAllPermissions();

        Task<GetRoleForEditOutput> GetRoleForEdit(EntityDto input);
    }
}