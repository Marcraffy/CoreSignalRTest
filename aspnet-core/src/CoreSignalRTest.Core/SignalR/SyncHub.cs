using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Auditing;
using Abp.Dependency;
using Abp.Logging;
using Abp.RealTime;
using Microsoft.AspNetCore.SignalR;

namespace CoreSignalRTest.SignalR
{
    public class SyncHub : AbpCommonHub
    {

        private readonly IHubContext<SyncHub> context;
        public SyncHub(IOnlineClientManager onlineClientManager, 
            IClientInfoProvider clientInfoProvider,
            IHubContext<SyncHub> context) : base(onlineClientManager, clientInfoProvider)
        {
            this.context = context;
        }

        public async Task Sync(Type entityType)
        {
            await context.Clients.All.SendCoreAsync(entityType.Name, new object[0]);
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
