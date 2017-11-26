using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.Facades.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.Services.Common;
using SocialNetwork.Entities;
using SocialNetworkBL.Services.Groups;
using Group = SocialNetwork.Entities.Group;

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
