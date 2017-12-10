using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkPL.Models
{
    public class InviteUsersToGroupModel
    {
        public BasicUserDto User { get; set; }
        public int? GroupId { get; set; }
        public UserFilterDto Filter { get; set; }
        public IEnumerable<BasicUserDto> Users { get; set; }
    }
}