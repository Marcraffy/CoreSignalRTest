using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using CoreSignalRTest.Configuration.Dto;

namespace CoreSignalRTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : CoreSignalRTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
