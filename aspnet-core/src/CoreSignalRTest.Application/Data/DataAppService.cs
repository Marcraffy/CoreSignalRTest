using Abp.AppFactory.Interfaces;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace CoreSignalRTest.Data
{
    public class DataAppService : AsyncCrudAppService<Data, DataDto>
    {
        private readonly ISyncHub syncHub;

        public DataAppService(
            IRepository<Data, int> repository,
            ISyncHub syncHub
            ) : base(repository)
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