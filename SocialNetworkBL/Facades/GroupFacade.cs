using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Groups;

namespace SocialNetworkBL.Facades
{
    public class GroupFacade : FacadeBase<Group, GroupDto, GroupFilterDto>
    {
        private readonly IGroupService _groupService;

        public GroupFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<Group, GroupDto, GroupFilterDto> service,
            IGroupService groupService
        ) : base(unitOfWorkProvider, service)
        {
            _groupService = groupService;
        }

        public async Task<IList<GroupDto>> GetGroupsContainingSubNameAsync(string subName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _groupService.GetGroupsContainingSubNameAsync(subName);
            }
        }
    }
}