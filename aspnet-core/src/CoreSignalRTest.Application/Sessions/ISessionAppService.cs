using System.Threading.Tasks;
using Abp.Application.Services;
using CoreSignalRTest.Sessions.Dto;

namespace CoreSignalRTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
