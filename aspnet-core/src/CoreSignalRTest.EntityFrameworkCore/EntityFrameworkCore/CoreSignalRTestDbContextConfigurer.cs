using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CoreSignalRTest.EntityFrameworkCore
{
    public static class CoreSignalRTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CoreSignalRTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CoreSignalRTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
