using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.GroupProfileDtos;

namespace SocialNetworkPL.Models
{
    public class ShowGroupUsersModel
    {
        public GroupDto Group { get; set; }
        public IEnumerable<GetGroupUsersDto> GroupUsers { get; set; }
    }
}