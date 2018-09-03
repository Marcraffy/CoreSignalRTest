using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.AspNetCore.SignalR.Hubs;

namespace CoreSignalRTest.SignalR
{
    public class SyncHub : AbpHubBase
    {
        public async Task Sync(string entityType)
        {
            await Clients.All.SendCoreAsync("Sync", new object[] { entityType });
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
