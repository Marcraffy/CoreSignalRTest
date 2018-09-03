using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using CoreSignalRTest.SignalR;

namespace CoreSignalRTest.Data
{
    public class DataAppService : AsyncCrudAppService<Data,DataDto>
    {
        private readonly SyncHub syncHub;

        public DataAppService(
            IRepository<Data, int> repository,
            SyncHub syncHub
            )
            : base(repository)
        {
            this.syncHub = syncHub;
        }

        public override async Task<DataDto> Create(DataDto input)
        {
            var output = await base.Create(input);
            await syncHub.Sync(typeof(DataDto));
            return output;
        }
    }
}
