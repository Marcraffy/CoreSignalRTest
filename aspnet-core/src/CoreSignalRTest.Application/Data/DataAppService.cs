using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;

namespace CoreSignalRTest.Data
{
    public class DataAppService : AsyncCrudAppService<Data,DataDto>
    {
        public DataAppService(Abp.Domain.Repositories.IRepository<Data, int> repository) : base(repository)
        {

        }
    }
}
