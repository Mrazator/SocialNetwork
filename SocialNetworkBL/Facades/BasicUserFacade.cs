using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.BasicUser;

namespace SocialNetworkBL.Facades
{
    public class BasicUserFacade : FacadeBase
    {
        private readonly IBasicUsersService _basicUsersService;

        public BasicUserFacade(IUnitOfWorkProvider unitOfWorkProvider, IBasicUsersService basicUsersService) : base(unitOfWorkProvider)
        {
            _basicUsersService = basicUsersService;
        }

        public async Task<BasicUserDto> GetUsersByNickName(string nickName)
        {
            using (UnitOfWorkProvider.Create())
            {
                return await _basicUsersService.GetUsersByNickName(nickName);
            }
        }
    }
}
