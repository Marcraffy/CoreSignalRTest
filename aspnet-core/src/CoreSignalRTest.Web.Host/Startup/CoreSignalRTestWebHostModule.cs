using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreSignalRTest.Configuration;

namespace CoreSignalRTest.Web.Host.Startup
{
    [DependsOn(
       typeof(CoreSignalRTestWebCoreModule))]
    public class CoreSignalRTestWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CoreSignalRTestWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreSignalRTestWebHostModule).GetAssembly());
        }
    }
}
