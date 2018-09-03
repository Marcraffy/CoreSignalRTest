using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CoreSignalRTest.Configuration;
using CoreSignalRTest.EntityFrameworkCore;
using CoreSignalRTest.Migrator.DependencyInjection;

namespace CoreSignalRTest.Migrator
{
    [DependsOn(typeof(CoreSignalRTestEntityFrameworkModule))]
    public class CoreSignalRTestMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CoreSignalRTestMigratorModule(CoreSignalRTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CoreSignalRTestMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CoreSignalRTestConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreSignalRTestMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
