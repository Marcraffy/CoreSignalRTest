using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using CoreSignalRTest.EntityFrameworkCore.Seed;

namespace CoreSignalRTest.EntityFrameworkCore
{
    [DependsOn(
        typeof(CoreSignalRTestCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class CoreSignalRTestEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<CoreSignalRTestDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        CoreSignalRTestDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        CoreSignalRTestDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CoreSignalRTestEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
