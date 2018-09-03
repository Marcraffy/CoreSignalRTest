using System.Threading.Tasks;
using CoreSignalRTest.Configuration.Dto;

namespace CoreSignalRTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
