using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;

namespace CoreSignalRTest.Data
{
    public class DataAppService : AsyncCrudAppService<Data,DataDto>
    {
        public DataAppService(
            Abp.Domain.Repositories.IRepository<Data, int> repository
            )
            : base(repository)
        {

        }

        public override Task<DataDto> Create(DataDto input)
        {
            var output = base.Create(input);
            
            return output;
        }
    }
}
