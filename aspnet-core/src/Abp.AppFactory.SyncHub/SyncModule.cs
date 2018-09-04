using Abp.AppFactory.Interfaces;
using Abp.Dependency;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Abp.AppFactory.Sync
{
    public class SyncModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<ISyncHub, SyncHub>(DependencyLifeStyle.Transient);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(SyncModule).GetAssembly());
        }
    }
}