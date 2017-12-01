using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects.Common;
using SocialNetworkBL.Services.Common;

namespace SocialNetworkBL.Facades.Common
{
    public class FacadeBase<TEntity, TDto, TFilterDto>
        where TFilterDto : FilterDtoBase, new()
        where TEntity : class, IEntity, new()
        where TDto : DtoBase
    {
        protected readonly CrudQueryServiceBase<TEntity, TDto, TFilterDto> Service;
        protected readonly IUnitOfWorkProvider UnitOfWorkProvider;

        protected FacadeBase(IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<TEntity, TDto, TFilterDto> service)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
            Service = service;
        }

        public async Task<QueryResultDto<TDto, TFilterDto>> GetAllItemsAsync()
        {
            using (UnitOfWorkProvider.Create())
            {
                return await Service.ListAllAsync();
            }
        }

        public async Task<TDto> GetAsync(int entityId)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await Service.GetAsync(entityId);
            }
        }

        public async Task<int> CreateAsync(TDto entity)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                Service.Create(entity);
                await uow.Commit();
                return entity.Id;
            }
        }

        public async Task UpdateAsync(TDto entity)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                await Service.Update(entity);
                await uow.Commit();
            }
        }

        public async Task<bool> DeleteAsync(int entityId)
        {
            using (var uow = UnitOfWorkProvider.Create())
            {
                if (await Service.GetAsync(entityId, false) == null)
                    return false;
                Service.Delete(entityId);
                await uow.Commit();
                return true;
            }
        }
    }
}