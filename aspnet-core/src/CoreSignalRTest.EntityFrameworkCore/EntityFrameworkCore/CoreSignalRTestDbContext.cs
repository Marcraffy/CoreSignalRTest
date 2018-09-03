using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CoreSignalRTest.Authorization.Roles;
using CoreSignalRTest.Authorization.Users;
using CoreSignalRTest.MultiTenancy;

namespace CoreSignalRTest.EntityFrameworkCore
{
    public class CoreSignalRTestDbContext : AbpZeroDbContext<Tenant, Role, User, CoreSignalRTestDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CoreSignalRTestDbContext(DbContextOptions<CoreSignalRTestDbContext> options)
            : base(options)
        {
        }
    }
}
