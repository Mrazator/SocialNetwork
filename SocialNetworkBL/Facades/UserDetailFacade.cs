﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.UnitOfWork;
using SocialNetwork.Entities;
using SocialNetworkBL.DataTransferObjects.Filters;
using SocialNetworkBL.DataTransferObjects.UserDetailDto;
using SocialNetworkBL.Facades.Common;
using SocialNetworkBL.Services.Common;
using SocialNetworkBL.Services.Users;
using SocialNetworkBL.Services.Posts;

namespace SocialNetworkBL.Facades
{
    public class UserDetailFacade : FacadeBase<User, UserDetailDto, UserFilterDto>
    {
        private readonly IUserService _userService;
        //private readonly IUserService _userService;
        //private readonly IUserService _userService;
        //private readonly IUserService _userService;


        public UserDetailFacade(
            IUnitOfWorkProvider unitOfWorkProvider,
            CrudQueryServiceBase<User, UserDetailDto, UserFilterDto> service,
            IUserService userService,
            IPostService postService

        ) : base(unitOfWorkProvider, service)
        {
            _userService = userService;
        }
    }
}