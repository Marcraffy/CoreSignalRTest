using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CoreSignalRTest.Configuration;
using CoreSignalRTest.Web;

namespace CoreSignalRTest.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CoreSignalRTestDbContextFactory : IDesignTimeDbContextFactory<CoreSignalRTestDbContext>
    {
        public CoreSignalRTestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CoreSignalRTestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CoreSignalRTestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CoreSignalRTestConsts.ConnectionStringName));

            return new CoreSignalRTestDbContext(builder.Options);
        }
    }
}
