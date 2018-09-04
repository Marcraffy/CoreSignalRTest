using Abp.AppFactory.Interfaces;
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
    }
}