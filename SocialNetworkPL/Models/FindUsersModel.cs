using System.Collections.Generic;
using SocialNetworkBL.DataTransferObjects;
using SocialNetworkBL.DataTransferObjects.Filters;

namespace SocialNetworkPL.Models
{
    public class FindUsersModel
    {
        public BasicUserDto User { get; set; }
        public UserFilterDto Filter { get; set; }
        public IEnumerable<BasicUserDto> Users { get; set; }
    }
}