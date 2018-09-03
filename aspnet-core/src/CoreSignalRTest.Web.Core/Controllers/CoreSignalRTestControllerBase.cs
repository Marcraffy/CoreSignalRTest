using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CoreSignalRTest.Controllers
{
    public abstract class CoreSignalRTestControllerBase: AbpController
    {
        protected CoreSignalRTestControllerBase()
        {
            LocalizationSourceName = CoreSignalRTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
