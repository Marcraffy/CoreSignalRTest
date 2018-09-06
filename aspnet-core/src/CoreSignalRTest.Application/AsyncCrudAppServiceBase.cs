using Abp.AppFactory.Interfaces;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using CoreSignalRTest.Authorization.Users;
using CoreSignalRTest.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace CoreSignalRTest
{
    public class AsyncCrudAppServiceBase<TEntity, TEntityDto> : AsyncCrudAppServiceBase<TEntity, TEntityDto, int>
        where TEntity : Entity
        where TEntityDto : EntityDto
    {
        public AsyncCrudAppServiceBase(IRepository<TEntity, int> repository, ISyncHub syncHub) : base(repository, syncHub)
        {
        }
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey> : AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto>
        where TEntity : Entity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, ISyncHub syncHub) : base(repository, syncHub)
        {
        }
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput> : AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TEntityDto, TEntityDto>
        where TEntity : Entity<TPrimaryKey>
        where TEntityDto : EntityDto<TPrimaryKey>
    {
        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, ISyncHub syncHub) : base(repository, syncHub)
        {
        }
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, ISyncHub syncHub) : base(repository, syncHub)
        {
        }
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput> : AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
    {
        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, ISyncHub syncHub) : base(repository, syncHub)
        {
        }
    }

    public class AsyncCrudAppServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput> : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>

        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        public TenantManager TenantManager { get; set; }

        public UserManager UserManager { get; set; }

        private readonly ISyncHub syncHub;

        public AsyncCrudAppServiceBase(IRepository<TEntity, TPrimaryKey> repository, ISyncHub syncHub) : base(repository)
        {
            this.syncHub = syncHub;
            LocalizationSourceName = CoreSignalRTestConsts.LocalizationSourceName;
        }

        protected virtual Task<User> GetCurrentUserAsync()
        {
            var user = UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
            if (user == null)
            {
                throw new Exception("There is no current user!");
            }

            return user;
        }

        protected virtual Task<Tenant> GetCurrentTenantAsync()
        {
            return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }

        protected Task Sync()
        {
            CurrentUnitOfWork.SaveChanges();
            return syncHub.Sync(typeof(TEntityDto));
        }

        public override async Task<TEntityDto> Create(TCreateInput input)
        {
            var output = await base.Create(input);
            await Sync();
            return output;
        }

        public override async Task<TEntityDto> Update(TUpdateInput input)
        {
            var output = await base.Update(input);
            await Sync();
            return output;
        }

        public override async Task Delete(TDeleteInput input)
        {
            await base.Delete(input);
            await Sync();
        }
    }
}