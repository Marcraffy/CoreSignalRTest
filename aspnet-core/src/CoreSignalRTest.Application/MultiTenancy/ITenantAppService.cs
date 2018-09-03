using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CoreSignalRTest.MultiTenancy.Dto;

namespace CoreSignalRTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
