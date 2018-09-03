using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreSignalRTest.Authorization;

namespace CoreSignalRTest
{
    [DependsOn(
        typeof(CoreSignalRTestCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CoreSignalRTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CoreSignalRTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CoreSignalRTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
