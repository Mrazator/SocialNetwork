using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using X.PagedList;

namespace SocialNetworkPL.Models
{
    public class UsersListViewModel
    {
        public IPagedList<UserDto> Users { get; set; }
        public UserFilterDto Filter { get; set; }
        public string SearchedSubname { get; set; }
    }
}