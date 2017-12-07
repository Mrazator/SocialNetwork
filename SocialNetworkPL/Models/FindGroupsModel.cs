using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetworkPL.Models
{
    public class FindGroupsModel
    {
        public BasicUserDto User { get; set; }
        public GroupFilterDto Filter { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}