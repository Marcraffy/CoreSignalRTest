using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Dependency;

namespace CoreSignalRTest.SignalR
{
    public class SyncHub : AbpCommonHub, ITransientDependency
    {
        public SyncHub(Abp.RealTime.IOnlineClientManager onlineClientManager, Abp.Auditing.IClientInfoProvider clientInfoProvider) : base(onlineClientManager, clientInfoProvider)
        {
        }

        public async Task Sync(Type entityType)
        {
            await Clients.All.SendCoreAsync(entityType.Name, new object[0]);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Users");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Users");
            await base.OnDisconnectedAsync(exception);
        }

    }
}
