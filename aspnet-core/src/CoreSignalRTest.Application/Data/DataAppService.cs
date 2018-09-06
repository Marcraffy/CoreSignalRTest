using Abp.AppFactory.Interfaces;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace CoreSignalRTest.Data
{
    public class DataAppService : AsyncCrudAppServiceBase<Data, DataDto>
    {

        public DataAppService(
            IRepository<Data, int> repository,
            ISyncHub syncHub
            ) : base(repository, syncHub)
        {
        }

        public override Task<DataDto> Update(DataDto input)
        {
            return base.Update(input);
        }

        public override async Task Delete(EntityDto<int> input)
        {
            await Repository.DeleteAsync(input.Id);
            await Sync();
        }
    }
}