using System;
using System.Threading.Tasks;

namespace Abp.AppFactory.Interfaces
{
    public interface ISyncHub
    {
        Task Sync(Type entityType);
    }
}
